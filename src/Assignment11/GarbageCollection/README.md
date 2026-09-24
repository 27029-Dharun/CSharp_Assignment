# Assignment 11

## Using Garbage Collection and Understanding Its Impact on Performance

### Garbage collector

The garbage collector can be triggered

- Manually by `GC.Collect()`.
- Automatically when a fixed threshold is reached.

It collects all the unreachable objects from the heap.

- **Automatic GC:** When the large number of objects are created and the number of unreachable objects increase above the threshold then the GC is called automatically.

- **GC.Collect():** When the GC is called the program execution is interrupted. So it can cause performance inpact in the application.

#### Roles of Garbage collector

- Manages memory
- It removes unused objects.
- Performs memory defragmentation.

#### Mark and Sweep

- The objects that can be removed are determined by the Mark and Sweep algorithm.
- If the object is reachable from the root then it is included in the graph of reachable object, all the other objects that are not present in the graph then it is removed by the Garbage collector.

#### Impact on Performance

- The Garbage collector requires CPU resources and can temporarily suspend the applicatoin threads while the runtime identifies and reclaims unreachable objects.
- Garbage collection is automatic and necessay, but object creation and unnecessary manual collections can reduce the performance of the application.
