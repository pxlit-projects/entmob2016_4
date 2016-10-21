package be.pxl.backend.services;

import be.pxl.backend.exceptions.UserException;
import be.pxl.backend.repositories.UserRepository;
import be.pxl.backend.models.*;
import java.util.*;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.authentication.encoding.ShaPasswordEncoder;
import org.springframework.stereotype.Service;

/**
 * Created by Jonas on 14/10/16.
 */

@Service
public class UserService {

    @Autowired
    private UserRepository userRepository;

    public User addUser(User user) throws Exception {
        if(user.getPassword() != null && user.getPassword().length() > 5) {
            String password = user.getPassword();
            ShaPasswordEncoder shaPasswordEncoder = new ShaPasswordEncoder(256);
            String hashed = shaPasswordEncoder.encodePassword(password, "");
            user.setPassword(hashed);
            user.setEnabled(true);
            return userRepository.save(user);
        } else {
            throw new UserException();
        }
    }

    public List<User> getAllUsers() {
        return (List<User>) userRepository.findAll();
    }

    public User getUserByUsername(String username) {
        return userRepository.getUserByUsername(username);
    }

}
