# install packages:

#pip install flask
#pip install psycopg2
#pip install imageai

from flask import Flask, request, abort, jsonify
import logging
import psycopg2
from config import config
from flask import send_file
from imageai.Prediction import ImagePrediction
import os
from werkzeug.utils import secure_filename
from flask import g

# set path
execution_path = os.getcwd()

app = Flask(__name__)
app.config['UPLOAD_FOLDER'] = "uploadedimgs"
ALLOWED_EXTENSIONS = set(['png', 'jpg', 'jpeg', 'gif'])

@app.route("/img", methods=['POST'])
def detect_img():
    # return nothing if no file
    if 'file' not in request.files:
        return jsonify("")

    file = request.files['file']

    if file.filename == '':
            flash('No selected file')
            return jsonify("")

    if file and allowed_file(file.filename):
        filename = secure_filename(file.filename)
        file.save(os.path.join(execution_path, filename))
        logging.debug(os.path.join(execution_path , filename));

        prediction = ImagePrediction()
        prediction.setModelTypeAsSqueezeNet()
        prediction.setModelPath(os.path.join(execution_path, "squeezenet_weights_tf_dim_ordering_tf_kernels.h5"))
        prediction.loadModel()

        predictions, probabilities = prediction.predictImage(os.path.join(execution_path, filename), result_count=5 )

        results = [];

        for eachPrediction, eachProbability in zip(predictions, probabilities):
            results.append((eachPrediction, eachProbability))

        os.remove(os.path.join(execution_path, filename))

        return jsonify(results)

def allowed_file(filename):
    return '.' in filename and \
           filename.rsplit('.', 1)[1].lower() in ALLOWED_EXTENSIONS

@app.route("/")
def hello():
    return "Server is running"

@app.route("/addData", methods=['POST'])
def addData():
    data = request.get_json()
    print(data)
    text = data['data']
    print(type(text))
    print(text)
    sql = "insert into testtable(data) values(%s) RETURNING id;"

    conn = None
    dataID = None

    try:
        params = config()
        conn = psycopg2.connect(**params)
        cur = conn.cursor()
        cur.execute(sql, (text,))
        dataID = cur.fetchone()
        conn.commit()
        cur.close()
    except (Exception, psycopg2.DatabaseError) as error:
        print(error)

    finally:
        if conn is not None:
            conn.close()

    return str(dataID)

@app.route("/getAllData", methods=['GET'])
def getAllData():
    sql="""SELECT * FROM testtable"""
    conn = None
    dataList = []


    try:
        params = config()
        conn = psycopg2.connect(**params)
        cur = conn.cursor()
        cur.execute(sql)
        allData = cur.fetchall()

        for singleData in allData:

            dataId = singleData[1]
            text = singleData[0]

            dataAsDict = {
                'id:': dataId,
                'text': text
            }

            dataList.append(dataAsDict);

    except (Exception, psycopg2.DatabaseError) as error:
        print(error)

    finally:
        if conn is not None:
            conn.close()
        return jsonify(dataList)

if __name__ == '__main__':
    app.run(debug=True)

