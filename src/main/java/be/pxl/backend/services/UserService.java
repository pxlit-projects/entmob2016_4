package be.pxl.backend.services;

import be.pxl.backend.repositories.UserRepository;
import be.pxl.backend.models.*;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

/**
 * Created by Jonas on 14/10/16.
 */

@Service
public class UserService {

    @Autowired
    private UserRepository userRepository;

    public User getUserById(int id) {
        return userRepository.findOne(id);
    }

    public User addUser(User user) {
        return userRepository.save(user);
    }

}
