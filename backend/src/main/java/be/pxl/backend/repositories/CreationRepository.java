package be.pxl.backend.repositories;

import be.pxl.backend.models.Creation;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

/**
 * Created by Jonas on 21/10/16.
 */

@Repository
public interface CreationRepository extends CrudRepository<Creation, Integer> {
}
