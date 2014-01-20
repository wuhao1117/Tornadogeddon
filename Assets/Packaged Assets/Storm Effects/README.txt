Storm Effects
by WeBee3D
v.1.1

Thank you for purchasing.
-----------------------------------------------
Notes

Made with Unity 3.5 - Shuriken Particle System
Minimum System Requirements: Unity 3.5
-----------------------------------------------
Installation

1) Download Storm Effects by WeBee3D
2) Navigate to the downloaded file, double click package file to open
3) Click Import, wait for package to install
-----------------------------------------------
Play a Scene

- In Unity, go to the Project tab 
- Expand the Storm Effects folder
- Expand the 1 - Scenes folder, notice all of the scene files
- Double click one of the scene files
- Wait for scene to load
- Click the Play button, or hit control P to play the scene
-----------------------------------------------
Drag a prefab into your scene

- In Unity, go to the Project tab  
- Expand the Storm Effects folder
- Expand the 2 - Particles folder
- Expand the Prefabs folder, notice all of the prefabs
- Click and hold a prefab while dragging the prefab into your scene window

+Note: Adjust the Position and Rotation of the prefab to suit your needs
+For position examples, open a scene from 1 - Scenes and note the transform information from the Inspector
-----------------------------------------------
Particle Collision

Non-mobile Rain and Snow Storm Effects contain particles that collide with the ground.
You must assign collision object(s) to the particle system in your scene.

To assign collision for particles in your scene:
- Load a Storm Effect into your scene
- Navigate to the Hierarchy tab and click the Storm Effect (for example: Snow Heavy)
- In the Inspector tab, notice there is a tab labeled Collision. Click on this tab to expand
- Notice the Planes area, click on the small grey round icon, choose a plane for collision from the list of choices

+Note: If you have more than one collision plane, click the black + icon in the collision tab to add more collision planes
-----------------------------------------------
Setup a Collision Plane for Rain and Snow
 *You must assign the collision plane inside the particle system. 

Example for "Snow_Heavy"
- Open the Snow_Heavy scene
- Click on "Snow_Heavy" in the Hierarchy window
- Open the "Particle Effect" window
- Expand the "Collision" tab
- Notice the "planes" area. 
- Assign your collision plane

Note: In Unity 3.5+ Shuriken only supports particle collision for flat planes. Support will be added for particle collision with terrain meshes in Unity 4.0. 
-----------------------------------------------
Adjust Prewarm Settings

Rain, Snow, Tornado, and Wind have start delay settings to transition the effects from being off to on, over a few seconds. Depending on your needs, this may not be the desired effect. If you prefer to begin the scene with the effect already playing, or prewarmed, see below.

To adjust Prewarm settings:
- Load a Storm Effect into your scene
- Navigate to the Hierarchy tab and click the Storm Effect
- In the Inspector tab, find the Prewarm setting and check the box

The Storm Effect will now instantly begin playing when the scene begins.
-----------------------------------------------
Adjust Color & Transparency Settings to Match Your Scene

Storm Effects were designed to look best with the Demo Scene included with the pack. 
You may need to adjust color and transparency settings to best match your scene.

- Load a Storm Effect into your scene
- Navigate to the Hierarchy tab and click the Storm Effect
- In the Inspector tab, find the Color over Lifetime and click the rectangular window to spawn the Gradient Editor window
- In the Gradient Editor window, click the small nodes on the top and bottom of the rectangle
- The top nodes control alpha transparency, the bottom nodes control color
-----------------------------------------------
Changing the Fog Settings in Unity

Fog settings are applied to the scene. They add a grey color to the default Storm Effects scene. If you are having problems getting particles to change color, try adjusting the fog color and the particle textures.  

Go to:
* Edit --> Render Settings
* Notice the Inspector tab
* Adjust Fog Color and Fog Density settings to get the look you would like to see.
(or turn off the fog completely by un-checking the Fog radio button)
-----------------------------------------------
Changing the Max Particle Size

* Load a cloud Prefab. (I will use Clouds Medium for this example)
* Click on the Clouds Medium prefab in the Hierarchy tab
* Go to the Inspector tab, expand the Renderer tab
* Notice the "Max Particle Size" field. It is set to "4"
* Try setting this number to "2" instead of "4". 

Changing the Max Particle Size setting to a lower value reduces the size of the particle as the camera gets closer to the particle. You may have to play with these settings to achieve the effect you are looking for, depending on your needs. Also, you may need to place the cloud emitter higher in the sky (+Y) if you are using this effect in an application where the camera gets close to the particle emitter. 
-----------------------------------------------

Mix & Match

Storm Effects are designed to work together.

Try adding a few different types of prefabs to the scene.

For Example:
Rain Heavy + Clouds Stormy = More Fun! 
-----------------------------------------------

ENJOY!

Storm Effects will be updated for Unity 4.0 compatibilty 



