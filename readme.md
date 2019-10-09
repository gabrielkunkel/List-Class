List Implementation
===================

## CustomList<T> - CustomList<T> Method

Removes the occurence of any items of CustomList<T> listed in second CustomList<T> following the minus operator.

```C#
public CustomList<T> c = CustomList<T> a -  CustomList<T> b
```

##### Parameters
**a** Custom list of type **T**
**b** Custom list of type **T**

##### Returns
**c** Custom list of type **T**

### Example

```C#
using System;
using System.Collections.Generic;
using List;

public class CustomListFixer {

	CustomList<int> testList = new CustomList<int>();
	CustomList<int> testListb = new CustomList<int>();

	CustomListFixer() 
	{
	
		testList.Add(0);
		testList.Add(1);
		testList.Add(2);
		testList.Add(3);
		testList.Add(4);

		testListb.Add(0);
		testListb.Add(1);
	}

	public CustomList<int> FixList() 
	{
		return testList - testListb;
	}

	public void RunResult() 
	{
		Console.WriteLine(FixList().toString);
	}

	/****

	[2, 3, 4] // exclude the members which were added to testListb

	***/

}
```
