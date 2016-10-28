package be.pxl.backend.services;

import be.pxl.backend.exceptions.UserException;
import be.pxl.backend.repositories.UserRepository;
import be.pxl.backend.models.*;
import java.util.*;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jms.core.JmsTemplate;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.stereotype.Service;

/**
 * Created by Jonas on 14/10/16.
 */

@Service
public class UserService {

    @Autowired
    private JmsTemplate jmsTemplate;

    @Autowired
    private UserRepository userRepository;

    public User addUser(User user) {
        if(user.getPassword() != null && user.getPassword().length() > 5) {
            String password = user.getPassword();
            BCryptPasswordEncoder passwordEncoder = new BCryptPasswordEncoder();
            String hashed = passwordEncoder.encode(password);
            user.setPassword(hashed);
            user.setEnabled(true);
            return userRepository.save(user);
        } else {
            jmsTemplate.send("LogQueue", s -> s.createTextMessage("Error creating user"));
            throw new UserException("Password cannot be null and must be 6 characters long");
        }
    }

    public List<User> getAllUsers() {
        return (List<User>) userRepository.findAll();
    }

    public User getUserByUsername(String username) {
        return userRepository.getUserByUsername(username);
    }

}
