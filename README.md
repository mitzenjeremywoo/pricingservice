
## Limitations

- Persisting and retrieving object to/from database can be a challenge. 

- Given the incummulative nature of certain operations such as divide and round up, re-calculating the price is almost impossible. Take for example currency conversion. The rate changes and re-calculating the order again would be impossible

- Code/classes object are constantly evolving while data stored will be fixed and might have de-serialization issue later - depending on what is being changed. 
- Improve unit tests
- Use Dependency injection tools
- Refactor to use testcontainer for end-to-end testing

