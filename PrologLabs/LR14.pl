


% 1.1

task1_1:- 
    readString(Str,N), 
    writeString(Str), write(", "), 
    writeString(Str), write(", "), 
    writeString(Str), write(", "), 
    write(N).

readString(Str,N):- 
    get0(Char), 
    readString(Char, [], 0, Str, N, _).

readString(Str,N, Flag):- 
    get0(Char), 
    readString(Char, [], 0, Str, N, Flag).

readString(-1,Str,N,Str,N,1):-!.
readString(10,Str,N,Str,N,0):-!.

readString(Char,NowStr,Count,Str,N, Flag):-
    NewCount is Count+1, 
    appendString(NowStr,[Char],NewNowStr), 
    get0(NewChar), 
    readString(NewChar,NewNowStr,NewCount,Str,N, Flag).

appendString([],X,X).
appendString([X|T],Y,[X|T1]) :- appendString(T,Y,T1).

writeString([]):-!.
writeString([H|T]):-put(H),writeString(T).



% 1.2

task1_2:- 
    readString(Str,_), 
    wordsCount(Str,Count),
    write(Count).

wordsCount([],Count):-Count is 1,!.
wordsCount([H|T], Count):-
	    H is 32,
		wordsCount(T,N),
		Count is N+1;
		wordsCount(T,Count).

% 1.3 Дана строка, определить самое частое слово

task1_3 :- readString(Str, _), mostCommonWord(Str, X), writeString(X).



countWordString(List, X, Ans) :- 
    countWordString(List, X, 0, Ans).
countWordString([], _, Ans, Ans) :- !.
countWordString([X|T], X, Count, Ans) :- 
    NewCount is Count + 1, 
    countWordString(T, X, NewCount, Ans),!.
countWordString([_|T], X, Count, Ans) :- 
    countWordString(T, X, Count, Ans),!.

splitString([], _, CurWord, CurWordList, Ans) :- 
    appendString(CurWordList, [CurWord], NewWL), 
    Ans = NewWL,!.

splitString([Separator|T], Separator, CurWord, CurWordList, Ans) :- 
    appendString(CurWordList, [CurWord], NewWL), 
    splitString(T, Separator, [], NewWL, Ans),!.

splitString([S|T], Separator, CurWord, CurWordList, Ans) :- 
    appendString(CurWord, [S], NewWord), 
    splitString(T, Separator, NewWord, CurWordList, Ans),!.

splitString(Str, Separator, Ans) :- 
    char_code(Separator, SepCode), 
    splitString(Str, SepCode, [], [], Ans).



mostCommonWord(Str, Ans) :-
    splitString(Str, " ", Words), 
    mostCommonWord(Words, Words, 0, [], Ans). 

mostCommonWord(Words, [Word|T], CurMaxCnt, _, Ans) :- 
    countWordString(Words, Word, Cnt), 
    Cnt > CurMaxCnt, 
    NewMax is Cnt, 
    NewMaxWord = Word, 
    mostCommonWord(Words, T, NewMax, NewMaxWord, Ans),!.

mostCommonWord(Words, [_|T], CurMaxCnt, CurMaxWord, Ans) :- 
    mostCommonWord(Words, T, CurMaxCnt, CurMaxWord, Ans),!.

mostCommonWord(_, [], _, Ans, Ans) :-!.



% 1.4

task1_4 :- readString(Str, N), task1_4(Str, N).

subString([H|T], Start, End, Ans) :- 
    subString([H|T], Start, End, 0, [], Ans).

subString([H|T], Start, End, I, List, Ans) :- 
    I >= Start, I < End, 
    appendString(List, [H], NewList), 
    NewI is I + 1, 
    subString(T, Start, End, NewI, NewList, Ans),!.

subString([_|T], Start, End, I, List, Ans) :- 
    NewI is I + 1, 
    subString(T, Start, End, NewI, List, Ans),!.

subString([], _, _, _, Ans, Ans) :- !.

writeStringNTimes(_, 0) :- !. 
writeStringNTimes(Str, N) :- 
    writeString(Str), 
    NewN is N - 1,
    writeStringNTimes(Str, NewN),!. 

task1_4(Str, N) :- 
    N > 5, 
    subString(Str, 0, 3, First3), 
    L3 is N - 3, 
    subString(Str, L3, N, Last3), 
    writeString(First3), 
    write(" "), 
    writeString(Last3),!.

task1_4([H|_], N) :- writeStringNTimes([H], N).

% 1.5

task1_5 :- 
    readString(Str, N), 
    NewN is N - 1, 
    subString(Str, NewN, N, [Char|_]), 
    indexesCharacter(Str, Char, Ans), 
    write(Ans).

indexesCharacter(List, X, Ans) :- 
    indexesCharacter(List, X, 0, [], Ans).

indexesCharacter([X|T], X, I, List, Ans) :- 
    appendString(List, [I], NewList), 
    NewI is I + 1, 
    indexesCharacter(T, X, NewI, NewList, Ans),!.

indexesCharacter([_|T], X, I, List, Ans) :- 
    NewI is I + 1, 
    indexesCharacter(T, X, NewI, List, Ans),!.

indexesCharacter([], _, _, Ans, Ans) :- !.

% 2.1

task2_1 :- see('LR14_Files/file1.txt'), readStringList(StrList), seen, maxLengthList(StrList, MaxLen), write(MaxLen),!.

count([X|T], Ans) :- 
    count([X|T], 0, Ans).

count([_|T], Count, Ans) :- 
    NewCount is Count + 1, 
    count(T, NewCount, Ans), !.

count([], Ans, Ans) :- !.



readStringList(List) :- 
    readString(A,_,Flag), 
    readStringList([A],List,Flag).

readStringList(List,List,1) :- !.

readStringList(Cur_list,List,0) :- 
    readString(A,_,Flag), 
    (not(A = []), append(Cur_list,[A],C_l),
    readStringList(C_l,List,Flag); 
    readStringList(Cur_list,List,Flag)),!.



maxLengthList(List, Ans) :- 
    maxLengthList(List, 0, Ans).

maxLengthList([H|T], CurMax, Ans) :- 
    count(H, NewMax), 
    NewMax > CurMax, 
    maxLengthList(T, NewMax, Ans), !.

maxLengthList([_|T], CurMax, Ans) :- 
    maxLengthList(T, CurMax, Ans), !.

maxLengthList([], Ans, Ans) :- !.






