


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

task2_1 :- see('LR14_Files/file1.txt'), readStringList(StringsList), seen, maxLengthList(StringsList, MaxLen), write(MaxLen),!.

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
    (not(A = []), appendString(Cur_list,[A],C_l),
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

% 2.2

task2_2 :- 
    see('LR14_Files/file1.txt'), 
    readStringList(StringsList), 
    seen, 
    countNoSpacesStrings(StringsList, Count), 
    write(Count),!.

countCharacter(Str, Char, Ans) :- 
    char_code(Char, CharCode), 
    countCharacter(Str, CharCode, 0, Ans).

countCharacter([S|T], Char, Count, Ans) :- 
    S = Char, 
    NewCount is Count + 1, 
    countCharacter(T, Char, NewCount, Ans),!.

countCharacter([_|T], Char, Count, Ans) :- 
    countCharacter(T, Char, Count, Ans), !.

countCharacter([], _, Ans, Ans) :- !.



countNoSpacesStrings(StringsList, Ans) :- 
    countNoSpacesStrings(StringsList, 0, Ans),!.

countNoSpacesStrings([H|T], Count, Ans) :- 
    countCharacter(H, " ", SpaceCount), 
    SpaceCount is 0, 
    NewCount is Count + 1, 
    countNoSpacesStrings(T, NewCount, Ans),!.

countNoSpacesStrings([_|T], Count, Ans) :- 
    countNoSpacesStrings(T, Count, Ans),!.

countNoSpacesStrings([], Ans, Ans) :- !.

% 2.3

task2_3 :- 
    see('LR14_Files/file2.txt'), 
    readStringList(StringsList), 
    seen, 
    count(StringsList, Len), 
    countCharacterList(StringsList, "a", Count1), 
    countCharacterList(StringsList, "A", Count2), 
    Count is Count1 + Count2, 
    Avg is Count / Len, 
    writeStringMoreA(StringsList, Avg).



countCharacterList(List, Char, Ans) :- 
    countCharacterList(List, Char, 0, Ans),!.

countCharacterList([H|T], Char, Count, Ans) :- 
    countCharacter(H, Char, Count1), 
    NewCount is Count + Count1, 
    countCharacterList(T, Char, NewCount, Ans),!.

countCharacterList([], _, Ans, Ans) :- !.



writeStringMoreA([H|T], Avg) :- 
    countCharacter(H, "a", Count1), 
    countCharacter(H, "A", Count2), 
    Count is Count1 + Count2, 
    Count > Avg, 
    writeString(H), nl,
    writeStringMoreA(T, Avg),!.

writeStringMoreA([_|T], Avg) :- writeStringMoreA(T, Avg), !.

writeStringMoreA([], _) :- !.

% 2.4

task2_4 :- 
    see('LR14_Files/file3.txt'), 
    readStringList(StringList), 
    seen, 
    stringsListToString(StringList, BigString), 
    mostCommonWordList(BigString, Word), 
    writeString(Word).


mostCommonWordList(Words, Ans) :- 
    mostCommonWord(Words, Words, 0, [], Ans).


stringsListToString(StrList, Ans) :- 
    stringsListToString(StrList, [], Ans).

stringsListToString([H|T], List, Ans) :- 
    splitString(H, " ", StrWords), 
    appendString(List, StrWords, NewList),
    stringsListToString(T, NewList, Ans), !.

stringsListToString([], Ans, Ans) :- !.

% 2.5

task2_5 :- 
    see('LR14_Files/file4.txt'), 
    readStringList(StrList), 
    seen, 
    stringsListToString(StrList, Words), 
    repeatingWords(Words, RepWords),
    tell('LR14_Files/outFile2_5.txt'), 
    writeNoRepeatingWordsStrings(StrList, RepWords), 
    told. 


inList([X|_], X).
inList([_|T] ,X) :- inList(T, X).

containsList(List, [H|_]) :- inList(List, H), !.
containsList(List, [_|T]) :- containsList(List, T).



repeatingWords(Words, Ans) :- 
    repeatingWords(Words, [], [], Ans).

repeatingWords([H|T], List, RepList, Ans) :- 
    inList(List, H), 
    appendString(List, [H], NewList),
    appendString(RepList, [H], NewRepList),  
    repeatingWords(T, NewList, NewRepList, Ans),!.

repeatingWords([H|T], List, RepList, Ans) :- 
    appendString(List, [H], NewList), 
    repeatingWords(T, NewList, RepList, Ans),!.

repeatingWords([], _, Ans, Ans) :- !.



writeNoRepeatingWordsStrings([H|T], RepWords) :- 
    splitString(H, " ", Words), 
    not(containsList(Words, RepWords)), 
    writeString(H), nl, 
    writeNoRepeatingWordsStrings(T, RepWords), !.

writeNoRepeatingWordsStrings([_|T], RepWords) :- 
    writeNoRepeatingWordsStrings(T, RepWords), !.

writeNoRepeatingWordsStrings([], _) :- !.

% 3 - 3

task3_3 :- 
    readString(Str, _),
    splitString(Str, " ", Words),
    randomSortList(Words, NewWords),
    wordsToString(NewWords, String),
    writeString(String).



wordsToString([H|T], Ans) :-
    wordsToString([H|T], [], Ans),!.

wordsToString([H|T],  List, Ans) :-
    wordsToString2(H, List, NewList), 
    appendString(NewList, [32], NewList2),
    wordsToString(T, NewList2, Ans).

wordsToString([], Ans, Ans).

wordsToString2([H|T], List, Ans) :-
    appendString(List, [H], NewList),
    wordsToString2(T, NewList, Ans).

wordsToString2([], Ans, Ans).



valueByIndex([H|T], Index, Ans) :-
    valueByIndex([H|T], 0, Index, Ans),!.
    
valueByIndex([Ans|_], Index, Index, Ans).

valueByIndex([_|T], CurIndex, Index, Ans) :-
    NewCurIndex is CurIndex + 1,
    valueByIndex(T, NewCurIndex, Index, Ans).



swapInList([H|T], Index1, Index2, Ans) :-
    swapInList([H|T], [H|T], 0, Index1, Index2, [], Ans),!.

swapInList(List, [H|T], CurIndex, Index1, Index2, SpawList, Ans) :-
    NewCurIndex is CurIndex + 1,
    (
    CurIndex is Index1,
    valueByIndex(List, Index2, Value),
    appendString(SpawList, [Value], NewSpawList),
    swapInList(List, T, NewCurIndex, Index1, Index2, NewSpawList, Ans)
    ;
    CurIndex is Index2,
    valueByIndex(List, Index1, Value),
    appendString(SpawList, [Value], NewSpawList),
    swapInList(List, T, NewCurIndex, Index1, Index2, NewSpawList, Ans)
    ;
    appendString(SpawList, [H], NewSpawList),
    swapInList(List, T, NewCurIndex, Index1, Index2, NewSpawList, Ans)
    ).

swapInList(_, [], _, _, _, Ans, Ans).



randomSortList([H|T], Ans) :-
    count([H|T], Length),
    randomSortList([H|T], 0, 5, Length, Ans),!.

randomSortList([H|T], CurIndex, MaxIndex, Length, Ans) :-
    NewCurIndex is CurIndex + 1,
    NewCurIndex < MaxIndex,
    random(0, Length, RandIndex1),
    random(0, Length, RandIndex2),
    swapInList([H|T], RandIndex1, RandIndex2, NewList),
    randomSortList(NewList, NewCurIndex, MaxIndex, Length, Ans).

randomSortList(Ans, _, _, _, Ans).
