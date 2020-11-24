

def Word_Separator():

    with open('EnglishWords84095.txt', errors='ignore') as words:
        for word in words:
            word = word.replace('\n','')
            word_n = len(word)
            if word_n == 4:
                with open('Word4.txt','a') as word4:
                    word4.write(word + '\n')
            elif word_n == 5:
                with open('Word5.txt','a') as word5:
                    word5.write(word + '\n')
            elif word_n == 6:
                with open('Word6.txt','a') as word6:
                    word6.write(word + '\n')
            else:
                pass

Word_Separator()
    

    