# pip install --upgrade tensorflow
# pip install opencv-python 
# pip install keras
# pip install imageai

# het heeft even geduurd maar ik heb iets gevonden
# dat simpel te gebruiken is :^)


# import library
from imageai.Detection import ObjectDetection
import os

# set path
execution_path = os.getcwd()

# maak detector en laad model
detector = ObjectDetection()
detector.setModelTypeAsYOLOv3()
detector.setModelPath( os.path.join(execution_path , "yolo.h5"))
detector.loadModel()

# doe detections
detections = detector.detectObjectsFromImage(input_image=os.path.join(execution_path , "sample.jpg"), output_image_path=os.path.join(execution_path , "output.jpg"), minimum_percentage_probability=30)

# iterate door detections en print alle results
for eachObject in detections:
    print(eachObject["name"] , " : ", eachObject["percentage_probability"], " : ", eachObject["box_points"] )

# als we dit gebruiken op de server:
# - laad de detector bij startup en doe detection alleen bij request
# zo verminderen we de delay etc etc
# laden van models kan namelijk even duren..