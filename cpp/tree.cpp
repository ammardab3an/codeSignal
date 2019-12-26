#include<bits/stdc++.h>

using namespace std;

template<typename T>
 struct Tree {
   Tree(const T &v) : value(v), left(nullptr), right(nullptr) {}
   T value;
   Tree *left;
   Tree *right;
 };

vector<int> traverseTree(Tree<int> * t) {

    vector<int> elements;

    queue<Tree<int> *> que; if(t) que.push(t);
    while(!que.empty())
    {
        Tree<int> * tt = que.front(); que.pop();

        elements.push_back(tt -> value);

        if(tt -> left) que.push(tt -> left);
        if(tt -> right)que.push(tt -> right);
    }

    return elements;
}
int main()
{
    Tree<int> t(5);
    t.left  = new Tree<int>(10);
    t.right = new Tree<int>(20);

    for(auto element : traverseTree(&t))
        cout << element << endl;
    return 0;
}

