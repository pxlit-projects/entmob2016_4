package be.pxl.backend.repositories;

import be.pxl.backend.models.Temperature;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

/**
 * Created by Jonas on 7/10/16.
 */

@Repository
public interface TemperatureRepository extends CrudRepository<Temperature, Integer> {

    @Transactional(readOnly = true)
    @Query(value = "select t from Temperature t where t.session.id =:id")
    List<Temperature> getTemperaturesForSession(@Param(value = "id") int id);

}
