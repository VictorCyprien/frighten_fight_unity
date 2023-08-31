# Frighten Fight

The application simulates a virtual environment to help people overcome their phobias.

The phobias featured in the game are :

- Arachnophobia (fear of spiders)
- Ophiophobia (fear of snakes)
- Acrophobia (fear of heights)

## How to install ?

1. Open a new terminal
2. Clone this repository
    
    - With HTTPS :
        - `git clone https://github.com/VictorCyprien/frighten_fight_unity.git`

    - With SSH :
        - `git clone git@github.com:VictorCyprien/frighten_fight_unity.git`

3. Move to the project

    - `cd /frighten_fight_unity`

4. Launch the app with Unity
5. After launching the application, navigate to the "Assets/Scenes/SampleScene" folder to load the scene.

## Activate DEBUG Mode
To simulate the client and server, navigate to the "CheckPlatform" gameobject and check DEBUG mode.

![Activate DEBUG mode](/Docs/img/debug.PNG "Activate DEBUG mode")

When you launch the application, you can simulate the client side by moving the camera with the arrow keys.

## Skybox, sound and model management

### Skyboxs

Skyboxes are located in the "Assets/Resources/Materials" folder.

Each skybox is named as follows :

phobie_view_difficulty_number

Where phobie is the current phobia, difficulty is the type (easy, medium or hard) and number is the difficulty level number.

For example, for spider level 5 : arachnophobia_view_medium_2

For snake level 8 : ophiophobia_view_hard_3

Each skybox have a image named phobienumber where number is actual level

### Sounds

Sounds are located in the "Assets/Resources/Sounds" folder.

Each sound is named as follows :

phobie_sound_difficulty_number

Where phobie is the current phobia, difficulty is the type (easy, medium or hard) and number is the difficulty level number.

For example, for spider level 5 : arachnophobia_sound_medium_2

For snake level 8 : ophiophobia_sound_hard_3


### Models

Models are located in the "Assets/Prefabs" folder.

Each phobie have a folder.


## Documentation

The code is full documentated. You can view in the "Assets/Resources/Scripts" folder

The documentation is generated with [Doxygen](https://www.doxygen.nl/)

You can access the documentation with the shortcut "Accueil Doc.Ink" located in the folder "Docs" when downloading the repository
