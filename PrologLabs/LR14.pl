


% 1.1

task1_1:- 
    readString(Str,N), 
    writeString(Str), write(", "), 
    writeString(Str), write(", "), 
    writeString(Str), write(", "), 
    write(N).

readString(Str,N):- 
    get0(Char), 
    readString(Char, [], 0, Str, N).

readString(10,Str,N,Str,N):-!.

readString(Char,NowStr,Count,Str,N):-
    NewCount is Count+1, 
    appendString(NowStr,[Char],NewNowStr), 
    get0(NewChar), 
    readString(NewChar,NewNowStr,NewCount,Str,N).

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



count(List, X, Ans) :- 
    count(List, X, 0, Ans).
count([], _, Ans, Ans) :- !.
count([X|T], X, CurCnt, Ans) :- 
    NewCnt is CurCnt + 1, 
    count(T, X, NewCnt, Ans),!.
count([_|T], X, CurCnt, Ans) :- 
    count(T, X, CurCnt, Ans),!.



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
    count(Words, Word, Cnt), 
    Cnt > CurMaxCnt, 
    NewMax is Cnt, 
    NewMaxWord = Word, 
    mostCommonWord(Words, T, NewMax, NewMaxWord, Ans),!.

mostCommonWord(Words, [_|T], CurMaxCnt, CurMaxWord, Ans) :- 
    mostCommonWord(Words, T, CurMaxCnt, CurMaxWord, Ans),!.

mostCommonWord(_, [], _, Ans, Ans) :-!.

