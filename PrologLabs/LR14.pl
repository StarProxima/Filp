

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

% 1.1
task1_1:- 
    readString(Str,N), 
    writeString(Str), write(", "), 
    writeString(Str), write(", "), 
    writeString(Str), write(", "), 
    write(N).