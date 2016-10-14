package be.pxl.backend.repositories;

import be.pxl.backend.models.AcceleroMeter;
import org.springframework.boot.orm.jpa.EntityScan;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

/**
 * Created by Jonas on 7/10/16.
 */

@Repository
public interface AcceleroMeterRepository extends CrudRepository<AcceleroMeter, Integer> {

    @Query(value = "select a from AcceleroMeter a")
    List<AcceleroMeter> getAcceleroMetersForSession(int id);

}
