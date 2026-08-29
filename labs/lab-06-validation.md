# Lab 06 — Validation and Error Handling

## Objective
Return predictable failures that a frontend can use.

## Starting Point
Checkout `lab-06-start`.

## Steps
1. Require a non-blank title.
2. Limit title to 120 and description to 1000 characters.
3. Validate status and priority enum values.
4. Return validation problems for HTTP 400 and problem details for 404/500.

## Validation
POST an empty title and confirm HTTP 400 with `errors.Title`; request an unknown id and confirm HTTP 404.

## Recovery
Checkout `lab-06-solution` and inspect `TaskRequestValidator` plus endpoint responses.

## Expected Result
The API failure contract is consistent and actionable.
