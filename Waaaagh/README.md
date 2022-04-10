# Svelto.ECS.Schema Example: Waaaagh

## Abstract

This example shows how to write effective code with ECS, with Svelto.ECS and Schema extensions.



## Layered System

I separated game logic into multiple layers, each layers are capsulated and devided with assembly definition. This means you can manage dependencies of each layer, and a layer doesn't have to know how other layers work. You'll only expose shared components and interfaces.

This additionally, prevents any issue from accidentally qurying a wrong entity. Because filtering is based on interface rows, not combination of components.
