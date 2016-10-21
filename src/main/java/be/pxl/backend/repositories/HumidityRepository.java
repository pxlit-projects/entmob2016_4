package be.pxl.backend.repositories;

import be.pxl.backend.models.Humidity;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.data.repository.query.Param;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

/**
 * Created by Jonas on 7/10/16.
 */
public interface HumidityRepository extends CrudRepository<Humidity, Integer> {

    @Transactional(readOnly = true)
    @Query(value = "select h from Humidity h where h.session.id =:id")
    List<Humidity> getHumidityForSession(@Param(value = "id") int id);

}
