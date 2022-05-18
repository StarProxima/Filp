

% 11 - 39

print_even_uneven_index_list([Elem|Tail]) :- print_even_uneven_index_list([Elem|Tail], [Elem|Tail], 1),!.

print_even_uneven_index_list([], [],_).
print_even_uneven_index_list(List, [],_):- print_even_uneven_index_list([], List, 0).
print_even_uneven_index_list(List, [Elem|Tail], Index) :-
    (0 is Index mod 2,
    write(Elem), write(' '),
    NewIndex is Index+1,
    print_even_uneven_index_list(List, Tail, NewIndex);
    NewIndex is Index+1,
    print_even_uneven_index_list(List, Tail, NewIndex)).


% 12 - 45

inInteval(Elem, A,B, X):- Elem > A, Elem < B, X is Elem.
inInteval(_, _,_, 0).

sum_interval([], _, _, 0).
sum_interval([Elem|Tail], A, B, Ans) :- 
    inInteval(Elem, A, B, Inc),
    sum_interval(Tail, A, B, Ans1),
    Ans is Ans1 + Inc,!.

% 13 - 57

count_elem([Elem|Tail], Ans) :- count_elem([Elem|Tail], 0, Ans),!.

moreSum(Elem, Sum, Inc) :- Elem > Sum, Inc is 1.
moreSum(_, _, Inc) :-  Inc is 0.

count_elem([], _, 0).
count_elem([Elem|Tail], Sum, Ans):-
    moreSum(Elem, Sum, Inc),
    NewSum is Sum+Elem,
    count_elem(Tail, NewSum, Ans1),
    Ans is Ans1 + Inc.

% 14

add_find_list([Elem|_], Elem).
add_find_list([_|Tail], Elem) :- add_find_list(Tail, Elem).

get_answer14 :- get_answer14([_,_,_]).
get_answer14(List) :- 

    add_find_list(List,[belocurov,_]),
    add_find_list(List,[rizov,_]),
    add_find_list(List,[chernov,_]),

    add_find_list(List,[_,blondin]),
    add_find_list(List,[_,riziy]),
    add_find_list(List,[_,brunet]),

    not(add_find_list(List,[belocurov,brunet])),
    not(add_find_list(List,[belocurov,blondin])),
    not(add_find_list(List,[rizov,riziy])),
    not(add_find_list(List,[chernov,brunet])),

    write(List),!.


% 15
get_answer15 :- get_answer15([_,_,_]).
get_answer15(List) :-

    add_find_list(List,[anya,X,X]),
    add_find_list(List,[valya,_,_]),
    add_find_list(List,[natasha,_,green]),

    add_find_list(List,[_,white,_]),
    add_find_list(List,[_,green,_]),
    add_find_list(List,[_,blue,_]),

    add_find_list(List,[_,_,white]),
    add_find_list(List,[_,_,green]),
    add_find_list(List,[_,_,blue]),
    
    not(add_find_list(List,[valya,Y,Y])),
    not(add_find_list(List,[natasha,Z,Z])),
    
    not(add_find_list(List,[valya,_,white])),
    not(add_find_list(List,[valya,white,_])),
    
    write(List),!.

% 16
get_answer16 :- get_answer16([_,_,_]).
get_answer16(List) :-

    add_find_list(List,[_,_,1]),
    add_find_list(List,[_,_,2]),
    
    add_find_list(List,[_,slesar,0]),
    add_find_list(List,[_,tokar,X]),
    add_find_list(List,[_,svarshik,_]),
    

    add_find_list(List,[borisov,_,_]),
    add_find_list(List,[ivanov,_,_]),
    add_find_list(List,[semenov,_,Y]),

    Y > X,
    not(add_find_list(List,[borisov,slesar,_])),

    write(List),!.

% 17

near([Elem1,Elem2|_], Elem1,Elem2).
near([Elem2,Elem1|_], Elem1,Elem2).
near([_,Elem|Tail], Elem1,Elem2) :- 
    near([Elem|Tail], Elem1,Elem2).

between(Center,Elem1,Elem2, [Elem1,Center,Elem2|_]).
between(Center,Elem1,Elem2, [Elem2,Center,Elem1|_]).
between(Center,Elem1,Elem2, [_,El1,El2|Tail]) :-
    between(Center, Elem1, Elem2, [El1,El2|Tail]).

get_answer17 :- get_answer17([_,_,_,_]).
get_answer17(List) :-

    add_find_list(List,[butilka,_]),
    add_find_list(List,[stakan,_]),
    add_find_list(List,[kuvshin,_]),
    add_find_list(List,[banka,_]),
    add_find_list(List,[_,moloko]),
    add_find_list(List,[_,limonad]),
    add_find_list(List,[_,kvas]),
    add_find_list(List,[_,voda]),

    not(add_find_list(List,[butilka,voda])),
    not(add_find_list(List,[butilka,moloko])),
    not(add_find_list(List,[banka,limonad])),
    not(add_find_list(List,[banka,voda])),

    % not(add_find_list(List,[kuvshin,kvas])),
    % not(add_find_list(List,[banka,moloko])),

    between([_,limonad],[_,kvas],[kuvshin,_],List),
    near(List, [stakan,_],[banka,_]),
    near(List, [stakan,_],[_,moloko]),
    write(List).

% 18
get_answer18 :- get_answer18([_,_,_,_]).
get_answer18(List) :-

    add_find_list(List,[voronov,_]),
    add_find_list(List,[pavlov,_]),
    add_find_list(List,[levitsky,_]),
    add_find_list(List,[sakharov,_]),

    add_find_list(List,[_,tantsor]),
    add_find_list(List,[_,r34artist]),
    add_find_list(List,[_,pevets]),
    add_find_list(List,[_,pisatel]),

    not(add_find_list(List,[voronov,pevets])),
    not(add_find_list(List,[levitsky,pevets])),

    not(add_find_list(List,[pavlov,pisatel])),
    not(add_find_list(List,[pavlov,r34artist])),

    not(add_find_list(List,[sakharov,pisatel])),
    not(add_find_list(List,[voronov,pisatel])),

    (add_find_list(List,[voronov,r34artist]), not(add_find_list(List,[levitsky,pisatel]));
    add_find_list(List,[levitsky,pisatel]), not(add_find_list(List,[voronov,r34artist]))),
    
    write(List).

% 19
get_answer19 :- get_answer19([_,_,_]).
get_answer19(List) :-
    
    add_find_list(List,[maykl,basketball,_,A]),
    add_find_list(List,[saimon,_,israeli,C]),
    add_find_list(List,[richard,_,_,_]),

    add_find_list(List,[_,basketball,_,_]),
    add_find_list(List,[_,tennis,_,D]),
    add_find_list(List,[_,cricket,_,1]),

    add_find_list(List,[_,_,american,B]),
    add_find_list(List,[_,_,israeli,_]),
    add_find_list(List,[_,_,australian,_]),

    add_find_list(List, [_,_,_,2]),
    add_find_list(List, [_,_,_,3]),
    
    A < B,
    C < D,

    write(List).

% 20
get_answer20 :- get_answer20([_,_,_]).
get_answer20(List) :-
    
    add_find_list(List,[aladar,_,_]),
    add_find_list(List,[bela,_,_]),
    add_find_list(List,[balash,_,_]),

    add_find_list(List,[_,budapest,_]),
    add_find_list(List,[_,bekeschaba,_]),
    add_find_list(List,[_,asoda,_]),

    add_find_list(List,[_,budapest,aptekar]),
    add_find_list(List,[_,_,buhalter]),
    add_find_list(List,[_,_,agronom]),

    not(add_find_list(List,[balash,budapest,_])),

    (add_find_list(List,[aladar,asoda,agronom]),
    add_find_list(List,[bela,bekeschaba,buhalter]);

    add_find_list(List,[aladar,asoda,agronom]),
    add_find_list(List,[balash,bekeschaba,buhalter])),

    write(List).