#include<bits/stdc++.h>
using namespace std;

std::vector<std::string> Arr;
bool can[20][20];
int vist = 0;
int sz;

bool Can(std::string s1, std::string s2)
{
    int cnt = 0;
    for(int i = 0; i < s1.size(); i++)
        if(s1[i] != s2[i]) if(cnt++)
            return false;
    return cnt == 1;
}

bool go(int lastPos)
{
    if (vist == (1 << sz) -1)
        return true;

    for(int i = 0; i < sz; i++)
        if(i != lastPos and !(vist & (1 << i)) and can[lastPos][i])
        {
            vist += 1 << i;
            if(go(i))
                return true;
            vist -= 1 << i;
        }

    return false;
}

bool stringsRearrangement(std::vector<std::string> inputArray) {
    Arr = inputArray;
    sz = inputArray.size();

    for(int i = 0; i < sz; i++)
    for(int j = 0; j < sz; j++)
        can[i][j] = Can(inputArray[i], inputArray[j]);

    for(int i = 0; i < sz; i++)
    {
        vist = 1 << i;
        if(go(0))
            return true;
    }
    return false;
}

int main()
{
    cout << stringsRearrangement({"aa", "bb", "ab"}) << endl;
}
