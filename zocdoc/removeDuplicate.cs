//without using Linq
public List<String> removeDuplicate(List<String> input)
{
	//this implementation has time complexity of O(2n) and space complexity of O(2n)
	//which is still better than pure List<String> implementation.
	List<String> returnList = new List<String>();
	Hashtable ht = new Hashtable();
	
	foreach (String s in input)
	{
		if (!ht.ContainsKey(s))
		{
			ht.Add(s, "");
			returnList.Add(s);
		}
	}
	
	return returnList;
}

//using Linq
input.GroupBy(x => x).Where(group => group.Count() > 1).Select(group => Group.Key).ToList();
//easy huh? :)
