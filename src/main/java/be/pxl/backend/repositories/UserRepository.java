package be.pxl.backend.repositories;

import be.pxl.backend.models.User;
import org.springframework.data.repository.CrudRepository;

/**
 * Created by Jonas on 7/10/16.
 */

public interface UserRepository extends CrudRepository<User, Integer> {

}

