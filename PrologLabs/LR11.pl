man(voeneg).
man(ratibor).
man(boguslav).
man(velerad).
man(duhovlad).
man(svyatoslav).
man(dobrozhir).
man(bogomil).
man(zlatomir).

woman(goluba).
woman(lubomila).
woman(bratislava).
woman(veslava).
woman(zhdana).
woman(bozhedara).
woman(broneslava).
woman(veselina).
woman(zdislava).

parent(voeneg,ratibor).
parent(voeneg,bratislava).
parent(voeneg,velerad).
parent(voeneg,zhdana).

parent(goluba,ratibor).
parent(goluba,bratislava).
parent(goluba,velerad).
parent(goluba,zhdana).

parent(ratibor,svyatoslav).
parent(ratibor,dobrozhir).
parent(lubomila,svyatoslav).
parent(lubomila,dobrozhir).


parent(boguslav,bogomil).
parent(boguslav,bozhedara).
parent(bratislava,bogomil).
parent(bratislava,bozhedara).

parent(velerad,broneslava).
parent(velerad,veselina).
parent(veslava,broneslava).
parent(veslava,veselina).

parent(duhovlad,zdislava).
parent(duhovlad,zlatomir).
parent(zhdana,zdislava).
parent(zhdana,zlatomir).

% 11
daughter(X,Y):- parent(Y,X),woman(X).
daughter(X) :- daughter(Y,X), write(Y).

% 12 
wife(X,Y) :- parent(X,Z),parent(Y,Z),woman(X),man(Y).
wife(X) :- wife(Y,X), print(Y).

% 13 
grand_da(X,Y):-woman(X),parent(Y,Z),parent(Z,X).
grand_dats(X):-grand_da(Y,X),write(Y),nl,fail.

% 14
grand_ma_and_da(X,Y) :- woman(Y),woman(X),(grand_da(X,Y);grand_da(Y,X)).

% 15
min_digit_up(X,C) :- X < 10, C is X.
min_digit_up(X,Y) :- 
    D is X div 10,
    min_digit_up(D,C),
    M is X mod 10,
    Y is min(M,C).

