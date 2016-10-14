package be.pxl.backend.repositories;

import be.pxl.backend.models.Temperature;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

/**
 * Created by Jonas on 7/10/16.
 */

@Repository
public interface TemperatureRepository extends CrudRepository<Temperature, Integer> {

    List<Temperature> getTemperaturesForSession(int id);

}
