package be.pxl.backend.dao;

import be.pxl.backend.models.User;

/**
 * Created by Jonas on 7/10/16.
 */

public interface UserDao {

    User getUserById(int id);
    User addUser(User user);
}

