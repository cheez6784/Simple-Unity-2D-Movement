# Simple-Unity-2D-Movement
A simple C# script for unity 2D movement


# Important READ THIS:
This is a Rigidbody 2D system.
Any preset values work best for a Unity 2D capsule. Play with this how you would like to. 
The optimal friction value I found is 0.2
In the layer dropdown select a layer (I would create a custom one) and make sure everything that you want to have proper jumping on is on that layer.
I plan to add toggleable features such as cyote time into the system in the future.
In the code, I maximized the velocity on the player to avoid the player overjumping. This is probably a horrible way to do this but it works :/
If you do not want a slight tilt when you move, freeze the rigidbody's Z rotation under "constraints"

### This is basic, and is a starting point for a cool movement system.
