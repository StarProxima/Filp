

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
