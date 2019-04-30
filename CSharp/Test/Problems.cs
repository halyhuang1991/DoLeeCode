using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSharp.Test
{
    public class Problems
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
        public static int MySqrt(int x)
        {
            if (x <= 1) return x;
            int left = 0, right = x;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (x / mid >= mid) left = mid + 1;
                else right = mid;
            }
            return right - 1;
        }
        public int MaxSubArray2(int[] nums)
        {

            if (nums == null || nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];
            int len = nums.Length;
            int sum = 0; int result = int.MinValue;
            for (int i = 0; i < len; i++)
            {
                sum = sum + nums[i];
                sum = sum > nums[i] ? sum : nums[i];
                if (sum > result)
                {
                    result = sum;
                }
            }
            return result;
        }
        public int MaxSubArray(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];
            int result = nums[0];
            int len = nums.Length;
            for (int i = 0; i < len - 1; i++)
            {
                int sum = nums[i];
                if (sum > result) result = sum;
                for (int j = i + 1; j < len; j++)
                {
                    sum += nums[j];
                    if (sum > result) result = sum;
                }
            }
            if (nums[len - 1] > result) result = nums[len - 1];
            return result;

        }
        public int SearchInsert(int[] nums, int target)
        {
            int r = 0;
            foreach (int n in nums)
            {
                if (n < target)
                {
                    r++;
                }
                else
                {
                    break;
                }
            }
            return r;
        }
        public static int StrStr(string haystack, string needle)
        {
            if (haystack == null || needle == null) return -1;
            // var index=haystack.IndexOf(needle);
            // if(index==-1)return -1;
            // return index;
            if (needle == "") return 0;
            if (haystack == needle) return 0;
            var r = -1;
            char first = needle[0];
            int haylen = haystack.Length;
            int needleLen = needle.Length;
            for (int i = 0; i < haylen; i++)
            {
                if (haystack[i] != first) continue;
                if (haylen - i < needleLen) break;
                int j = i;
                bool rb = true;
                for (int p = 0; p < needleLen; p++)
                {
                    if (needle[p] != haystack[j])
                    {
                        rb = false; break;
                    }
                    j++;
                }
                if (rb)
                {
                    r = i; break;
                }
            }
            return r;
        }
        public static int LengthOfLastWord(string s)
        {
            char[] crr = s.Trim().ToCharArray();
            int len = crr.Length;
            if (len == 1) return 1;
            int sum = 0;
            for (int i = len - 1; i >= 0; i--)
            {
                if (crr[i] == ' ')
                {
                    return sum;
                }
                else
                {
                    sum++;
                }
            }
            return sum;
        }
        public static int RemoveElement(int[] nums, int val)
        {
            int res = 0;
            for (int i = 0; i < nums.Length; ++i)
            {
                if (nums[i] != val) nums[res++] = nums[i];
            }
            return res;
        }
        public static int RomanToInt(string s)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            dic.Add('I', 1);
            dic.Add('V', 5);
            dic.Add('X', 10);
            dic.Add('L', 50); dic.Add('C', 100);
            dic.Add('D', 500); dic.Add('M', 1000);
            int sum = 0; char[] carr = s.ToCharArray();
            for (int ii = 0; ii < carr.Length - 1; ii++)
            {
                bool ret = true;
                if (carr[ii] == 'I' && (carr[ii + 1] == 'V' || carr[ii + 1] == 'X'))
                {
                    ret = false;
                }
                if (carr[ii] == 'X' && (carr[ii + 1] == 'L' || carr[ii + 1] == 'C'))
                {
                    ret = false;
                }
                if (carr[ii] == 'C' && (carr[ii + 1] == 'D' || carr[ii + 1] == 'M'))
                {
                    ret = false;
                }
                if (!ret)
                {
                    sum -= dic[carr[ii]];
                }
                else
                {
                    sum += dic[carr[ii]];
                }
            }
            sum += dic[carr[carr.Length - 1]];
            return sum;
        }
        public static int RemoveDuplicates(int[] nums)
        {
            if (nums == null) return 0;
            if (nums.Count() == 0) return 0;
            if (nums.Count() == 1) return 1;
            int first = nums[0];
            List<int> ls = new List<int>();
            int ii = 1;
            for (int i = 1; i < nums.Count(); i++)
            {
                if (first == nums[i])
                {
                    ii++;
                }
                else
                {
                    ls.Add(nums[i]);
                }
            }
            if (ii == 1)
            {
                return nums.Count();
            }
            else
            {
                return RemoveDuplicates(ls.ToArray()) + 1;
            }

        }
        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode tmp = new ListNode(-1);
            tmp.next = l1;
            ListNode curr = tmp;
            while (l2 != null && l1 != null)
            {
                int currval = curr.val;
                if (l2.val >= l1.val)
                {
                    curr.next = new ListNode(l1.val);
                    l1 = l1.next;
                }
                else
                {
                    curr.next = new ListNode(l2.val);
                    l2 = l2.next;
                }
                curr = curr.next;
            }
            while (l2 != null)
            {
                curr.next = new ListNode(l2.val);
                l2 = l2.next;
                curr = curr.next;
            }
            while (l1 != null)
            {
                curr.next = new ListNode(l1.val);
                l1 = l1.next;
                curr = curr.next;
            }
            return tmp.next;
        }
        public static bool IsPalindrome(int x)
        {
            if (x < 0) return false;
            if (x == 0) return true;
            int i = 0; int cx = x;
            List<int> ls = new List<int>();
            while (cx != 0)
            {
                i = cx % 10;
                ls.Add(i);
                cx = cx / 10;
            }
            int r = 0;
            foreach (int y in ls)
            {
                r = r * 10 + y;
            }
            if (r == x)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsValid(string s)
        {
            string left = "({["; string right = ")}]";
            bool ret = true;
            int i = 0;
            Stack st = new Stack();
            while (i < s.Length)
            {
                if (left.IndexOf(s[i]) >= 0 || right.IndexOf(s[i]) >= 0)
                {
                    if (right.IndexOf(s[i]) > 0)
                    {
                        if (st.Count == 0)
                        {
                            ret = false; break;
                        }
                        char leftprev = (char)st.Peek();
                        if (left.IndexOf(leftprev) == right.IndexOf(s[i]))
                        {
                            st.Pop();
                        }
                        else
                        {
                            ret = false; break;
                        }
                    }
                    else
                    {
                        st.Push(s[i]);
                    }
                }
                i++;
            }
            if (st.Count > 0) ret = false;
            return ret;

        }
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0) return "";
            for (int j = 0; j < strs[0].Length; ++j)
            {
                for (int i = 0; i < strs.Length; ++i)
                {
                    if (j >= strs[i].Length || strs[i][i] != strs[0][j])
                    {
                        return strs[i].Substring(0, j);
                    }
                }
            }
            return strs[0];

        }
        public string LongestCommonPrefix1(string[] strs)
        {
            if (strs == null) return "";
            if (strs.Length == 0) return "";
            if (strs.Length == 1) return strs[0];
            string a = strs[0]; string b = strs[1];
            if (a == "" || b == "") return "";
            if (strs.Length == 2)
            {
                return GetCommon(a, b);
            }
            else
            {
                string c = GetCommon(a, b);
                List<string> list = strs.ToList();
                list.RemoveAt(0);
                strs = list.ToArray();
                strs[0] = c;
                return LongestCommonPrefix1(strs);
            }

        }
        public string GetCommon(string a, string b)
        {

            string ret = ""; int i = 0; string r = "";
            while (ret.Length <= a.Length && i < a.Length)
            {
                ret += a[i];
                if (b.IndexOf(ret) == 0)
                {
                    r = ret;
                }
                i++;
            }
            return r;
        }
        public static int Reverse(int x)
        {
            if (x == 0)
                return 0;
            int result = 0;

            while (x != 0)
            {
                if (result > int.MaxValue / 10 || result < int.MinValue / 10)
                    return 0;
                result = result * 10 + x % 10;
                x /= 10;
            }

            return result;
        }
        public static ListNode reverseList(ListNode head)
        {
            ListNode dummy = new ListNode(-1);
            ListNode ptmp = head;
            while (ptmp != null)
            {
                ListNode pNex = ptmp.next;//2 3 => 3 null  //先将链表的下一项记录下来
                ptmp.next = dummy.next;//1 ->2 1 ->3 2 1
                dummy.next = ptmp;//-1 1=>-1 2 1 =>-1 3 2 1
                ptmp = pNex;//1 2 3=> 2 3 => 3 =>null
            }
            return dummy.next;
        }
        public static ListNode reverseList1(ListNode node)
        {
            if (node == null || node.next == null)
            {
                return node;
            }
            else
            {
                ListNode headNode = reverseList1(node.next);//获取下一项链表
                node.next.next = node;//下一项链表的下一个指针位置指向当前链表
                node.next = null;//当前链表的下一项指针位置 设置为空 为终止条件返回当前链表
                return headNode;
            }
        }

        public static ListNode CopyList(ListNode l1)
        {
            ListNode dummy = new ListNode(-1);
            ListNode cur = dummy;
            while (l1 != null)
            {
                cur.next = new ListNode(l1.val);
                cur = cur.next;
                if (l1 != null) l1 = l1.next;
            }
            cur.next = new ListNode(6);
            cur = cur.next;
            return dummy.next;
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode dummy = new ListNode(-1);
            ListNode cur = dummy;
            int carry = 0;
            while (l1 != null || l2 != null)
            {
                int d1 = l1 == null ? 0 : l1.val;
                int d2 = l2 == null ? 0 : l2.val;
                int sum = d1 + d2 + carry;
                carry = sum >= 10 ? 1 : 0;
                cur.next = new ListNode(sum % 10);
                cur = cur.next;
                if (l1 != null) l1 = l1.next;
                if (l2 != null) l2 = l2.next;
            }
            if (carry == 1) cur.next = new ListNode(1);
            return dummy.next;

        }
        public static int GetSum(int a, int b)
        {
            return (a & b) + (a | b);
        }
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
        public static int SingleNumber(int[] nums)
        {
            int r = nums[0];
            // for (int i = 0; i < nums.Length; i++)
            // {
            //     int temp = nums[i];
            //     bool ret = false;
            //     for (int j = 0; j < nums.Length; j++)
            //     {
            //         if (temp == nums[j]&&i!=j){ 
            //             ret = true;break;
            //         }
            //     }
            //     if (!ret)
            //     {
            //         r = temp; break;
            //     }
            // }
            for (int i = 1; i < nums.Length; i++)
            {
                r = r ^ nums[i];
            }
            return r;
        }
        public static bool HasPathSum1(TreeNode root, int sum)
        {
            if (root == null) return false;
            if (sum == root.val && sum >= 0)
            {
                return true;
            }
            else
            {
                if (root.left == null)
                {
                    return sum - root.val == 0;
                }
                else
                {
                    return HasPathSum1(root.left, sum - root.val);
                }
            }
        }
        public static bool HasPathSum(TreeNode root, int sum)
        {
            TreeNode curr = root;
            int sl = 0;
            while (curr != null)
            {
                sl += curr.val; System.Console.WriteLine(curr.val);
                curr = curr.left;
            }
            return sl == sum;
        }
        public string AddBinary(string a, string b)
        {
            string ret = "";
            int la = a.Length;
            int lb = b.Length;
            if (la == 0) { return b; }
            if (lb == 0) { return a; }
            int lmax = Math.Max(la, lb);
            char add = '0';
            for (int i = 0; i < lmax; i++)
            {
                char ca = la > i ? a[la - i - 1] : '0';
                char cb = lb > i ? b[lb - i - 1] : '0';
                char s = (ca == cb ? '0' : '1');
                char sj = (s == add ? '0' : '1');
                if (ca == '1' && cb == '1'
                        || s == '1' && add == '1')
                {
                    add = '1';
                }
                else
                {
                    add = '0';
                }
                ret += sj;
            }
            if (add == '1')
            {
                ret += add;
            }
            ret = string.Join("", ret.Reverse().ToArray());
            return ret;
        }
        public static int[] TwoSum(int[] nums, int target)
        {
            bool ret = false;
            int[] r = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                int j = i + 1;
                while (j < nums.Length)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        r[0] = i; r[1] = j;
                        ret = true;
                        break;
                    }
                    j++;
                }
                if (ret) break;
            }
            return r;
        }
        public static string ConvertToTitle(int n)
        {

            if (n <= 90 - 64)
            {
                return ((char)(n + 64)).ToString();
            }
            int i = n % 26; int carray = 0;
            if (i == 0)
            {
                i = 90; carray = 1;
            }
            else
            {
                i = 64;
            }
            return ConvertToTitle((int)((n - n % 26 - carray) / 26)) + ((char)i).ToString();
        }
        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
            {
                return true;
            }
            if (p == null || q == null)
            {
                return false;
            }

            return (p.val == q.val &&
                   IsSameTree(p.left, q.left) &&
                   IsSameTree(p.right, q.right));

        }
        public static int TrailingZeroes(int n)
        {
            if (n < 5) return 0;
            if (n <= 10) return 1;
            return TrailingZeroes(n / 5) + n / 5;
        }
        public static string ToLowerCase(string str)
        {
            string ret = "";
            for (int i = 0; i < str.Length; i++)
            {
                int ascii = (int)str[i];
                if (65 <= ascii && ascii <= 90)
                {
                    ret += (char)(((int)str[i]) + (97 - 65));
                }
                else
                {
                    ret += str[i];
                }
            }
            return ret;
        }
        public static string LongestWord(string[] words)
        {
            int index = 0; decimal maxLen = decimal.MinValue;
            for (int i = 0; i < words.Length; i++)
            {
                decimal mutil = 0; int j = 0; decimal ascii = 0;
                while (j < words.Length)
                {
                    if (words[j] != words[i] && words[i].StartsWith(words[j]))
                    {
                        mutil += 1;
                    }
                    else
                    {
                        if (words[j] == words[i])
                        {
                            foreach (char cr in words[i])
                            {
                                ascii += (int)cr;
                            }
                        }
                    }
                    j++;
                }
                mutil = mutil - ascii / (30 * 10000);
                if (mutil > maxLen)
                {
                    maxLen = mutil;
                    index = i;
                }


            }
            return words[index];

        }
        public static int AddDigits(int num)
        {
            if (num < 10) return num;
            int result = 0; int per = 10;
            bool ret = true;
            while (num != 0)
            {
                if (num % per != 1)
                {
                    ret = false;
                }
                result += num % per;
                num = num / per;
                per = per * 10;
            }
            if (ret)
            {
                return result;
            }
            else
            {
                return AddDigits(result);
            }

        }
        public static int ThirdMax(int[] nums)
        {
            List<int> ls = new List<int>();
            foreach (int i in nums)
            {
                if (!ls.Contains(i)) ls.Add(i);
            }
            ls.Sort();
            ls.Reverse();
            if (ls.Count <= 2) return ls[0];
            int val = int.MinValue; int j = 0;
            for (int i = 0; i < ls.Count && j < 3; i++)
            {
                int tval = ls[i];
                if (tval != val)
                {
                    val = tval; j++;
                }
            }
            return val;

        }
        public static void Rotate(int[] nums, int k)
        {
            if (k == 0) return;
            int max = nums.Length - 1;
            while (max > 0)
            {
                int temp = nums[max];
                nums[max] = nums[max - 1];
                nums[max - 1] = temp;
                max = max - 1;
            }
            Rotate(nums, k - 1);
        }
        public static bool ValidPalindrome(string s)
        {
            bool ret = true;
            int i = 0; int j = s.Length - 1; int flg = 0;
            while (i <= s.Length / 2 && j >= s.Length / 2)
            {
                char left = s[i]; char right = s[j];
                if (left == right)
                {
                    i++; j--;
                }
                else
                {
                    if (flg != 0)
                    {
                        ret = false; break;
                    }
                    if (s[i + 1] == right)
                    {
                        i += 2; j--; flg += 1;
                    }
                    else if (left == s[j - 1])
                    {
                        i++; j -= 2; flg += 1;
                    }
                    else
                    {
                        ret = false; break;
                    }
                }
            }
            return ret;
        }
        public static ListNode MergeKLists(ListNode[] lists)
        {
            if (lists.Length == 0) return null;
            ListNode node = lists[0];
            for (int i = 1; i < lists.Length; i++)
            {
                node = MergeTwoLists(node, lists[i]);
            }
            return node;
        }
        private static ListNode mergeKLists(ListNode[] lists, int start, int end)
        {
            if (start == end)
            {
                return lists[start];
            }
            else if (start < end)
            {
                int mid = (end - start) / 2 + start;
                ListNode left = mergeKLists(lists, start, mid);
                ListNode right = mergeKLists(lists, mid + 1, end);
                return MergeTwoLists(left, right);
            }
            else
            {
                return null;
            }
        }
        public static double MyPow(double x, int n)
        {
            if (n == 0) return 1;
            if (n == 1) return x;
            if (n == -1) return 1 / x;
            double half = MyPow(x, n / 2);
            return half * half * MyPow(x, n % 2);
        }
        public static int FirstMissingPositive(int[] nums)
        {
            if (nums.Length == 0) return 1;
            int ret = 1;
            Array.Sort(nums);
            foreach (int item in nums)
            {
                if (item == ret)
                {
                    ret++;
                }
                else if (item > ret)
                {
                    return ret;
                }
            }
            return ret;
        }
        public static void MoveZeroes(int[] nums)
        {
            int i = 0;
            int j = 0;
            while (j < nums.Length)
            {
                if (nums[j] != 0)
                {
                    int temp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = temp;
                    i++;
                    j++;
                }
                else
                {
                    j++;
                }
            }
        }
        public static void ReverseString(char[] s)
        {
            char temp;
            for (int i = 0; i < (s.Length) / 2; i++)
            {
                temp = s[i];
                s[i] = s[s.Length - 1 - i];
                s[s.Length - 1 - i] = temp;
            }
        }
        public int[] SortedSquares(int[] A) {
            int[] ret=new int[A.Length];
            for(int i=0;i<A.Length;i++){
                ret[i]=A[i]*A[i];
            }
            // for (int i = 0; i < ret.Length - 1; i++)
            // {
            //     for (int j = i + 1; j < ret.Length; j++)
            //     {

            //         if (ret[i] > ret[j])
            //         {
            //             int temp = ret[i];
            //             ret[i] = ret[j];
            //             ret[j] = temp;
            //         }

            //     }
            //  }
            Array.Sort(ret);
             return ret;
        }
        public int Search(int[] nums, int target)
        { 
            int ret=-1;
            for(int i=0;i<nums.Length;i++){
                if(nums[i]==target){
                    return i;
                }
            }
            return ret;
        }
        public static int MissingNumber(int[] nums)
        {
            int n=nums.Length;
            return (n*(n+1)/2-nums.AsEnumerable().Sum());
        }
        public static int[] Intersect(int[] nums1, int[] nums2)
        { 
                 List<int> ls=new List<int>();
                 List<int> max=nums1.Length>nums2.Length?nums1.ToList():nums2.ToList();
                 List<int> min=nums1.Length>nums2.Length?nums2.ToList():nums1.ToList();
                 int len=min.Count;
                 for (int i = 0; i < len; i++)
                 {
                     int val=min[i];
                     int index=max.IndexOf(val);
                     if(index>=0){
                         ls.Add(val);
                         min.RemoveAt(i);max.RemoveAt(index);
                         len--;i--;
                     }
                 }
                 return ls.ToArray();
        }
        public static IList<int> SelfDividingNumbers(int left, int right)
        {
            IList<int>  ls =new List<int>();
            for(int i=left;i<=right;i++){
                bool ret=true;
                int item=i;
                while (item > 0)
                {
                    if(item.ToString().IndexOf("0")>=0){
                        ret = false;
                        break;
                    }
                    if(item % 10 == 0&&item==i){
                        ret = false;
                        break;
                    }
                    if (item % 10 == 0&&item>0)
                    {
                       item=item/10;
                       if(item % 10 == 0){
                            ret = false;
                            break;
                       }
                    }
                    if (i % (item % 10) != 0)
                    {
                        ret = false;
                        break;
                    }
                    item = (item - item % 10) / 10;
                }
                if(ret){
                    Console.WriteLine(i);
                    ls.Add(i);
                }
            }
            return ls;
        }
        public bool HasCycle(ListNode head)
        {
            ListNode next = head;
            while (next != null)
            {
                if (next.next == next)
                    return true;
                ListNode tmp = next.next;
                next.next = next;
                next = tmp;
            }
            return false;
        }
        public int RangeSumBST(TreeNode root, int L, int R)
        {
            int result = 0;
            if (root == null) return 0;
            if (root.val >= L && root.val <= R)
            {
                result += root.val;
            }
            result += RangeSumBST(root.left, L, R);
            result += RangeSumBST(root.right, L, R);
            return result;
        }
        public static int MaximumProduct(int[] nums)
        {
            Array.Sort(nums);
            int count = nums.Length;
            if (nums[count - 2] <= 0)
            {
                nums[count - 2] = nums[1]; nums[count - 3] = nums[0];
            }
            else
            {
                if (nums[count - 2] * nums[count - 3] < nums[1] * nums[0])
                {
                    nums[count - 2] = nums[1]; nums[count - 3] = nums[0];
                }
            }
            return nums[count - 1] * nums[count - 2] * nums[count - 3];
        }
    }
    public class MyHashSet
        {
          int[] nums ;
          public int index=0;
            /** Initialize your data structure here. */
            public MyHashSet()
            {
                nums = new int[128];    
            }

            public void Add(int key)
            {
                if(this.index<nums.Length){
                    nums[index]=key;
                }else{
                    int[] oldArr=nums;
                    nums=new int[oldArr.Length+1];
                    oldArr.CopyTo(nums,0);
                }
                 index++;

            }

            public void Remove(int key)
            {
               int i=-1;
               for(;i<=index;i++){
                   if(i==-1)continue;
                   if(nums[i]==key){
                        break;
                   }
               }
               if(i!=-1){
                   int j=i;
                   while(j<index){
                     nums[j]=nums[j++];
                   }
                   index--;
               }
            }

            /** Returns true if this set contains the specified element */
            public bool Contains(int key)
            {
                bool ret = false;
                for (int i = 0; i <= index; i++)
                {
                    if (nums[i] == key)
                    {
                        return true;
                    }
                }
                return ret;
            }

        }
}
