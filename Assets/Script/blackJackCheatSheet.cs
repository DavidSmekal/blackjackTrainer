using UnityEngine;


public class blackJackCheatSheet : MonoBehaviour {

    //returns 1 if hit. 2 if stand. 3 if double. 4 if split. 9 for unknown for now
    public int blackJackCheatSheetMethod(randomCards.CardObject firstPlayerCard, randomCards.CardObject secondPlayerCard, randomCards.CardObject firstDealerCard)
    {

        int returnValue = 0;

        var cheatSheet = new int[27, 10]
        {
               //   A  2  3  4  5  6  7  8  9  10
         /*8*/     {1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, 
         /*9*/     {1, 1, 3, 3, 3, 3, 1, 1, 1, 1},  
         /*10*/    {1, 3, 3, 3, 3, 3, 3, 3, 3, 1},  
         /*11*/    {3, 3, 3, 3, 3, 3, 3, 3, 3, 3}, 
         /*12*/    {1, 1, 1, 2, 2, 2, 1, 1, 1, 1}, 
         /*13*/    {1, 2, 2, 2, 2, 2, 1, 1, 1, 1},  
         /*14*/    {1, 2, 2, 2, 2, 2, 1, 1, 1, 1},  
         /*15*/    {1, 2, 2, 2, 2, 2, 1, 1, 1, 1},  
         /*16*/    {1, 2, 2, 2, 2, 2, 1, 1, 1, 1}, 
         /*17*/    {2, 2, 2, 2, 2, 2, 2, 2, 2, 2}, 
         /*A,2*/   {1, 1, 1, 1, 3, 3, 1, 1, 1, 1},
         /*A,3*/   {1, 1, 1, 1, 3, 3, 1, 1, 1, 1},  
         /*A,4*/   {1, 1, 1, 3, 3, 3, 1, 1, 1, 1},  
         /*A,5*/   {1, 1, 1, 3, 3, 3, 1, 1, 1, 1}, 
         /*A,6*/   {1, 1, 3, 3, 3, 3, 1, 1, 1, 1}, 
         /*A,7*/   {1, 2, 3, 3, 3, 3, 2, 2, 1, 1}, 
         /*A,8*/   {2, 2, 2, 2, 2, 2, 2, 2, 2, 2}, 
         /*2,2*/   {1, 4, 4, 4, 4, 4, 4, 1, 1, 1}, 
         /*3,3*/   {1, 4, 4, 4, 4, 4, 4, 1, 1, 1}, 
         /*4,4*/   {1, 1, 1, 1, 4, 4, 1, 1, 1, 1}, 
         /*5,5*/   {1, 3, 3, 3, 3, 3, 3, 3, 3, 1},  
         /*6,6*/   {1, 4, 4, 4, 4, 4, 1, 1, 1, 1}, 
         /*7,7*/   {1, 4, 4, 4, 4, 4, 4, 1, 1, 1}, 
         /*8,8*/   {4, 4, 4, 4, 4, 4, 4, 4, 4, 4}, 
         /*9,9*/   {2, 4, 4, 4, 4, 4, 2, 4, 4, 2}, 
         /*10,10*/ {2, 2, 2, 2, 2, 2, 2, 2, 2, 2}, 
         /*A,A*/   {4, 4, 4, 4, 4, 4, 4, 4, 4, 4},

        };

        // I added -1 to firstDealerCard.value to make the index and the number align.

        // if there is a pair of aces, do this if statement
        if (firstPlayerCard.face == "Ace" && secondPlayerCard.face == "Ace")
        {
            returnValue = 4;
        }
        // if there is an Ace in one hand, do this if statement.
        else if (firstPlayerCard.face == "Ace" || secondPlayerCard.face == "Ace")
        {
            int firstPlayerCardValue = firstPlayerCard.value;
            int secondPlayerCardValue = secondPlayerCard.value;


            if (firstPlayerCardValue == 1 || secondPlayerCardValue == 1)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[9, i];
                    }

                }
            }
            if (firstPlayerCardValue == 2 || secondPlayerCardValue == 2)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[10, i];
                    }

                }
            }
            else if (firstPlayerCardValue == 3 || secondPlayerCardValue == 3)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[11, i];
                    }

                }
            }
            else if (firstPlayerCardValue == 4 || secondPlayerCardValue == 4)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[12, i];
                    }

                }
            }
            else if (firstPlayerCardValue == 5 || secondPlayerCardValue == 5)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[13, i];
                    }

                }
            }
            else if (firstPlayerCardValue == 6 || secondPlayerCardValue == 6)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[14, i];
                    }

                }
            }
            else if (firstPlayerCardValue == 7 || secondPlayerCardValue == 7)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[15, i];
                    }

                }
            }
            else if (firstPlayerCardValue == 8 || secondPlayerCardValue == 8)
            {

                returnValue = 2;
            }
            else if (firstPlayerCardValue == 9 || secondPlayerCardValue == 9)
            {
                returnValue = 2;
            }
            else if (firstPlayerCardValue == 10 || secondPlayerCardValue == 10)
            {
                returnValue = 2;
            }


        }
        // if there is a pair, do this if statement
        else if (firstPlayerCard.value == secondPlayerCard.value)
        {
            int firstPlayerCardValue = firstPlayerCard.value;

            if (firstPlayerCardValue == 2)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[17, i];
                    }

                }

            }

            else if (firstPlayerCardValue == 3)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[18, i];
                    }

                }

            }
            else if (firstPlayerCardValue == 4)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[19, i];
                    }

                }

            }
            else if (firstPlayerCardValue == 5)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[20, i];
                    }

                }

            }
            else if (firstPlayerCardValue == 6)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[21, i];
                    }

                }

            }
            else if (firstPlayerCardValue == 7)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[22, i];
                    }

                }

            }
            else if (firstPlayerCardValue == 8)
            {

                returnValue = 4;

            }
            else if (firstPlayerCardValue == 9)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[24, i];
                    }

                }

            }
            else if (firstPlayerCardValue == 10)
            {

                returnValue = 2;

            }

        }

        // else, if it's just a total of everything, do this statement
        else
        {

            int totalValue = firstPlayerCard.value + secondPlayerCard.value;

            if ((totalValue == 4) || (totalValue == 5) || (totalValue == 6) || (totalValue == 7))
            {
                returnValue = 1;
            }

            else if (totalValue == 8)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[0, i];
                    }

                }

            }
            else if (totalValue == 9)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[1, i];
                    }

                }
            }
            else if (totalValue == 10)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[2, i];
                    }

                }
            }
            else if (totalValue == 11)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[3, i];
                    }

                }
            }
            else if (totalValue == 12)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[4, i];
                    }

                }
            }
            else if (totalValue == 13)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[5, i];
                    }

                }
            }
            else if (totalValue == 14)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[6, i];
                    }

                }
            }
            else if (totalValue == 15)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[7, i];
                    }

                }
            }
            else if (totalValue == 16)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[8, i];
                    }

                }
            }
            else if (totalValue == 17)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[9, i];
                    }

                }
            }
            //this isn't in the matrix above.
            else if ((totalValue == 18) || (totalValue == 19) || (totalValue == 20) || (totalValue == 21))
            {
                returnValue = 2;
            }

        }


        return returnValue;


    }

    // this is a very ugly and bad way of doing this. I did this because in my "timed" game scene, I had to pass in randomCardsTimed instead of randomCards
    public int blackJackCheatSheetMethodTimed(randomCardsTimed.CardObject firstPlayerCard, randomCardsTimed.CardObject secondPlayerCard, randomCardsTimed.CardObject firstDealerCard)
    {

        int returnValue = 0;

        var cheatSheet = new int[27, 10]
        {
               //   A  2  3  4  5  6  7  8  9  10
         /*8*/     {1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, 
         /*9*/     {1, 1, 3, 3, 3, 3, 1, 1, 1, 1},  
         /*10*/    {1, 3, 3, 3, 3, 3, 3, 3, 3, 1},  
         /*11*/    {3, 3, 3, 3, 3, 3, 3, 3, 3, 3}, 
         /*12*/    {1, 1, 1, 2, 2, 2, 1, 1, 1, 1}, 
         /*13*/    {1, 2, 2, 2, 2, 2, 1, 1, 1, 1},  
         /*14*/    {1, 2, 2, 2, 2, 2, 1, 1, 1, 1},  
         /*15*/    {1, 2, 2, 2, 2, 2, 1, 1, 1, 1},  
         /*16*/    {1, 2, 2, 2, 2, 2, 1, 1, 1, 1}, 
         /*17*/    {2, 2, 2, 2, 2, 2, 2, 2, 2, 2}, 
         /*A,2*/   {1, 1, 1, 1, 3, 3, 1, 1, 1, 1},
         /*A,3*/   {1, 1, 1, 1, 3, 3, 1, 1, 1, 1},  
         /*A,4*/   {1, 1, 1, 3, 3, 3, 1, 1, 1, 1},  
         /*A,5*/   {1, 1, 1, 3, 3, 3, 1, 1, 1, 1}, 
         /*A,6*/   {1, 1, 3, 3, 3, 3, 1, 1, 1, 1}, 
         /*A,7*/   {1, 2, 3, 3, 3, 3, 2, 2, 1, 1}, 
         /*A,8*/   {2, 2, 2, 2, 2, 2, 2, 2, 2, 2}, 
         /*2,2*/   {1, 4, 4, 4, 4, 4, 4, 1, 1, 1}, 
         /*3,3*/   {1, 4, 4, 4, 4, 4, 4, 1, 1, 1}, 
         /*4,4*/   {1, 1, 1, 1, 4, 4, 1, 1, 1, 1}, 
         /*5,5*/   {1, 3, 3, 3, 3, 3, 3, 3, 3, 1},  
         /*6,6*/   {1, 4, 4, 4, 4, 4, 1, 1, 1, 1}, 
         /*7,7*/   {1, 4, 4, 4, 4, 4, 4, 1, 1, 1}, 
         /*8,8*/   {4, 4, 4, 4, 4, 4, 4, 4, 4, 4}, 
         /*9,9*/   {2, 4, 4, 4, 4, 4, 2, 4, 4, 2}, 
         /*10,10*/ {2, 2, 2, 2, 2, 2, 2, 2, 2, 2}, 
         /*A,A*/   {4, 4, 4, 4, 4, 4, 4, 4, 4, 4},

        };

        // I added -1 to firstDealerCard.value to make the index and the number align.

        // if there is a pair of aces, do this if statement
        if (firstPlayerCard.face == "Ace" && secondPlayerCard.face == "Ace")
        {
            returnValue = 4;
        }
        // if there is an Ace in one hand, do this if statement.
        else if (firstPlayerCard.face == "Ace" || secondPlayerCard.face == "Ace")
        {
            int firstPlayerCardValue = firstPlayerCard.value;
            int secondPlayerCardValue = secondPlayerCard.value;


            if (firstPlayerCardValue == 1 || secondPlayerCardValue == 1)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[9, i];
                    }

                }
            }
            if (firstPlayerCardValue == 2 || secondPlayerCardValue == 2)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[10, i];
                    }

                }
            }
            else if (firstPlayerCardValue == 3 || secondPlayerCardValue == 3)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[11, i];
                    }

                }
            }
            else if (firstPlayerCardValue == 4 || secondPlayerCardValue == 4)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[12, i];
                    }

                }
            }
            else if (firstPlayerCardValue == 5 || secondPlayerCardValue == 5)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[13, i];
                    }

                }
            }
            else if (firstPlayerCardValue == 6 || secondPlayerCardValue == 6)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[14, i];
                    }

                }
            }
            else if (firstPlayerCardValue == 7 || secondPlayerCardValue == 7)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[15, i];
                    }

                }
            }
            else if (firstPlayerCardValue == 8 || secondPlayerCardValue == 8)
            {

                returnValue = 2;
            }
            else if (firstPlayerCardValue == 9 || secondPlayerCardValue == 9)
            {
                returnValue = 2;
            }
            else if (firstPlayerCardValue == 10 || secondPlayerCardValue == 10)
            {
                returnValue = 2;
            }


        }
        // if there is a pair, do this if statement
        else if (firstPlayerCard.value == secondPlayerCard.value)
        {
            int firstPlayerCardValue = firstPlayerCard.value;

            if (firstPlayerCardValue == 2)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[17, i];
                    }

                }

            }

            else if (firstPlayerCardValue == 3)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[18, i];
                    }

                }

            }
            else if (firstPlayerCardValue == 4)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[19, i];
                    }

                }

            }
            else if (firstPlayerCardValue == 5)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[20, i];
                    }

                }

            }
            else if (firstPlayerCardValue == 6)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[21, i];
                    }

                }

            }
            else if (firstPlayerCardValue == 7)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[22, i];
                    }

                }

            }
            else if (firstPlayerCardValue == 8)
            {

                returnValue = 4;

            }
            else if (firstPlayerCardValue == 9)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[24, i];
                    }

                }

            }
            else if (firstPlayerCardValue == 10)
            {

                returnValue = 2;

            }

        }

        // else, if it's just a total of everything, do this statement
        else
        {

            int totalValue = firstPlayerCard.value + secondPlayerCard.value;

            if ((totalValue == 4) || (totalValue == 5) || (totalValue == 6) || (totalValue == 7))
            {
                returnValue = 1;
            }

            else if (totalValue == 8)
            {
                for (int i = 0; i < 10; i++)
                {

                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[0, i];
                    }

                }

            }
            else if (totalValue == 9)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[1, i];
                    }

                }
            }
            else if (totalValue == 10)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[2, i];
                    }

                }
            }
            else if (totalValue == 11)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[3, i];
                    }

                }
            }
            else if (totalValue == 12)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[4, i];
                    }

                }
            }
            else if (totalValue == 13)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[5, i];
                    }

                }
            }
            else if (totalValue == 14)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[6, i];
                    }

                }
            }
            else if (totalValue == 15)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[7, i];
                    }

                }
            }
            else if (totalValue == 16)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[8, i];
                    }

                }
            }
            else if (totalValue == 17)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == (firstDealerCard.value - 1))
                    {

                        returnValue = cheatSheet[9, i];
                    }

                }
            }
            //this isn't in the matrix above.
            else if ((totalValue == 18) || (totalValue == 19) || (totalValue == 20) || (totalValue == 21))
            {
                returnValue = 2;
            }

        }


        return returnValue;


    }
}
