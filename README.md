# CodeByContract Assignment 7

Members: Robert Elving, Simon Groenborg, Christopher Mortensen


## Purpose of using Code Contracts
The purpose of using Code Contracts by msdn is to state some rules, that should be followed in the future development of the project. 

Benefits:
* Static verification - Automatic checking whether there are any contract violations before running the program.
* Improve testing - Code contracts provide static contract verification, static checking and documentation generation. 

## Invariant 

The purpose of the Contract Invariant, is to apply rule(s) that must always be true, for each instance of the class.

If a instance of the Account-class follows these rules, it is considered to be a valid instance.

The Invariants are being checked during runtime when reaching the end of each public method. This is useful, since we wil make sure, that the instance will not be manipulated further in that particular method.

```cs 
[ContractInvariantMethod]
private void ObjectInvariant() {
    Contract.Invariant(Balance >= 0);
    Contract.Invariant(!String.IsNullOrWhiteSpace(Name));
}
```

## Abbreviator 

In the following codesnippet we have added two TransactionRules.
Works in many ways as the Invariant. You should specify when your Abbreviator should be invoked. 

We did it in Withraw(double amount) and Deposit(double amount)

```cs 
[ContractAbbreviator]
private void TransactionRules(double amount) {
    Contract.Requires(amount > 0, "Amount should be positive.");
    Contract.Requires<ArgumentException>(amount > 0, "Exception");
}
```

### invokation of the Abbreviator in our Withdraw method

```cs
 public double Withdraw(double amount) {
    Contract.Ensures(Contract.Result<double>() < Contract.OldValue(Balance));
    TransactionRules(amount);
            
    return Balance -= amount;
} 

```

## Usage of Pre-conditions
The usage of Pre-conditions validates the initial state of a method-call. It uses the Contract.Requires-method. See in our Abbreviator.

## Usage of Post-conditions
The usage of Post-conditions validates the exit state of a method. It uses the Contract.Ensures-method. See in our Withdraw function.
