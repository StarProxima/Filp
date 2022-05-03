

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

get_answer14:- get_answer14([_,_,_]).
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
get_answer15:- get_answer15([_,_,_]).
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
