package be.pxl.backend.repositories;

import be.pxl.backend.models.Temperature;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

/**
 * Created by Jonas on 7/10/16.
 */

@Repository
public interface TemperatureRepository extends CrudRepository<Temperature, Integer> {

    @Query(value = "select t from Temperature t")
    List<Temperature> getTemperaturesForSession();

}
