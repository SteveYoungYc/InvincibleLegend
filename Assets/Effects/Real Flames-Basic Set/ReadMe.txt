The Real Flames – Basic Set is a set of particle effects which are designed to be:
-	Realistic
-	Efficient (overdraw, particle count, memory)
-	Flexible (multiple sizes and multiple scales)

The Real Flames set is designed to allow you to drag and drop fire in to your environment as you need it.  Visual effects artists know that it is best to apply flames customized to each environment, which is what this set excels at.  With multiple sizes and directions it allows you create the environment of flames to fit your scene.

Included in Real Flames are sets of flames at four different scales to match your environment.  These scales are based on the height of your character. A standard 2.0 unit high character is the default.  Also included are environment scales for 4.0 unit, 1.0 unit, and 0.5 unit high characters.

At the heart of each set are three different flame effects, each in two directions.  In addition, each includes easily adjustable flickering lights, a standard campfire, and a torch effect specifically created to work while attached to a moving character or while stationary without excess particles.

Check out our Blackfire FX Vimeo channel for examples.

http://vimeo.com/user12362871 or search for person Blackfire FX.

FAQ:
1.	I’ve installed Real Flames, now what do I do?
Find the BFX_RealFlames directory in your project tab, open the folder for the scale you want to use, open the Particles folder, and just drag one of the effects into your scene.

2.	How do I choose which scale I should use?
Real Flames are designed to fit the scale of your environment.  Generally the scale of a project’s environment is based on the scale of the characters.  In Unity, a default character is approximately 2.0 units high, based on Unity’s default physics setup.  However, your environment may not match that scale so you have other scales to choose from.  If your environment is scaled for 1.0 unit high characters, then that’s the scale you should choose.  In addition to scales for environments with 2.0 and 1.0 unit characters, we have included scales for 0.5 and 4.0 unit characters.

3.	Can’t I just scale the effects to the size I want?
Unfortunately, Unity does not allow you to scale particle emitters.  Scaling has no visual effect on them.  You could scale the size of the particles within the emitters, but that would change the look of the effect and would just “fatten up” or “thin out” the effect and it would look wrong.

4.	What if I don’t want to use the scale based on the size of my character?
That’s completely up to you, it’s your project!  We have simply created these different scales for your convenience and labeled them for guidelines.

5.	Can I use flames from different scales in my project?
You certainly can!  However, you may notice that the effects from different scales don’t match up well, especially if they are next to each other.  This is because in real life, large flames act differently than small flames.  If you place a small fire from the 2.0 unit next to a medium fire from the 1.0 unit, you will see that they are approximately the same height.  However, they look completely different.  Real Flames have been designed as sets, so the size of the flames will match the environment of a specific scale.  You may even find it helpful to remove the other scales from your project tab once you determine which scale you need.

6.	The scales provided don’t match my environment.  Is there a set that is bigger/smaller than the ones that you have?
The Real Flames - Basic Set only has these four scales.  If you need a different scale, and we receive enough requests for that scale, we may provide additional ones at a later time.

7.	OK, enough about the scales, why are some of the particles labeled Front and some labeled Side?
If you place a small or medium fire in your scene, you may notice that the emitters are not circular, but elongated.  This is the same with the small versions as well, but it is not as noticeable.  The elongated emitter allows you to cover more area without the cost of additional overdraw. You will also notice that the flames tend to “blow” in the particle effect’s local Z direction.  This gives the flames a much more realistic motion.  The two different emitter directions allow you to put the axis of the emitter either parallel or perpendicular to the direction of the “wind” depending on how you want to construct the flames in your scene.

8.	Wouldn’t it just be easier to set the flames to all “blow” in the same world space direction instead of having two different local directions?
It would certainly be simpler for us to create them that way, but it wouldn’t be nearly as flexible for you to use them.  First, unless you want to go into each effect and change the direction, the flames would blow in the single direction that we designed them.  For example, they would always blow north.  If you want your flames to blow east, you would have to change each effect to blow to the east.
Second, different flames in the same scene will likely be blowing in different directions.  If you have flames on the south side of a building, flames blowing south will probably be OK.  If you put flames on the north side of that same building, blowing south would put the flames blowing through the wall, not away from it.  With the flames set to local space, you have the choice of putting each instance of the flames in the direction that works for you.

9.	That’s all nice, but how do I use the flickering lights?  I want my flames to cast light!
Within the scale you’ve chosen, there is a single light under the Lights folder with a script attached.  That script allows you to adjust the flickering of the light to what works best in your scene.  The parameters of the light (range, color, intensity, etc.) can be adjusted, just like any other light, to fit your environment.

10.	Why aren’t the lights attached to the particle effect in one prefab?
Multiple dynamic lights can easily get expensive to render.  Keeping the lights separate allows you to determine how many different lights are appropriate for your scene based on aesthetics as well as performance.  You get to control the efficiency of your scene.

11.	I have other questions not addressed here.  How can I contact you?
We welcome your comments, questions, suggestions and requests.  Simply email us at feedback@BlackfireFX.com.  We’d love to hear from you!


Regards,

The Blackfire FX Team
