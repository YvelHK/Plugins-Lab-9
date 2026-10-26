# Plugins-Lab-9

The Object Pool is implemented as a dictionary in the PlayerShooting class. Lasers are moved to the player's location and activated, and deactivate and return to the pool when they hit a target or reach the vertical limit

The Builder is implemented in the TargetBuilder class, and individually sets the targets' color, point value, hits to break, spawn location, and movement direction

The Observer is implemented in the ScoreObserver class and watches an event in the TargetHit class