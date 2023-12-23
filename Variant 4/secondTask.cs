class prog_2{
    static void Main(){
        string newString = "";
        Console.WriteLine("введите строку:");
        string str = "jjnfkf    djjdjd  kfkj kd";
        bool flag = false;
        foreach(char s in str){
            if(s != ' '){
                flag = false;
                newString += s;
            } else {
                if(!flag){
                    flag = true;
                    newString += s;
                }

            }
        }
        Console.WriteLine("(" + newString + ")");


    }
}