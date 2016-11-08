package be.pxl.backend.services;

import be.pxl.backend.exceptions.UserException;
import be.pxl.backend.jms.JmsSender;
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
    private JmsSender jmsSender;

    @Autowired
    private UserRepository userRepository;

    public void setJmsSender(JmsSender jmsSender) {
        this.jmsSender = jmsSender;
    }

    public void setUserRepository(UserRepository userRepository) {
        this.userRepository = userRepository;
    }

    public User addUser(User user) {
        if(user.getPassword() != null && user.getPassword().length() > 5) {
            String password = user.getPassword();
            BCryptPasswordEncoder passwordEncoder = new BCryptPasswordEncoder();
            String hashed = passwordEncoder.encode(password);
            user.setPassword(hashed);
            user.setEnabled(true);
            user.setRole("ROLE_USER");
            user = userRepository.save(user);
            jmsSender.sendMessage("add user with id:" + user.getId());
            return user;
        } else {
            UserException userException = new UserException("Password cannot be null and must be 6 characters long");
            jmsSender.sendMessage("add user error:" + userException.getMessage());
            throw userException;
        }
    }

    public List<User> getAllUsers() {
        List<User> users = (List<User>) userRepository.findAll();
        jmsSender.sendMessage("get all users");
        return users;
    }

    public User getUserByUsername(String username) {
        User user = userRepository.getUserByUsername(username);
        jmsSender.sendMessage("get user by name:" + user.getName());
        return user;
    }

}
