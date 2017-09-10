global main
extern be_elojeles_egesz
extern ki_elojeles_egesz
section .bss
    X resd 1
section .text
main:
    call be_elojeles_egesz
    cmp eax, 0
    jge kesz
    neg eax
kesz:
    push eax
    call ki_elojeles_egesz
    add esp, 4
    ret