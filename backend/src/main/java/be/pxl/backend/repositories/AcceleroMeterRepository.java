package be.pxl.backend.repositories;

import be.pxl.backend.models.AcceleroMeter;
import org.springframework.boot.orm.jpa.EntityScan;
import org.springframework.data.jpa.repository.Modifying;
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
public interface AcceleroMeterRepository extends CrudRepository<AcceleroMeter, Integer> {

    @Query(value = "select a from AcceleroMeter a where a.session.id =:id")
    List<AcceleroMeter> getAcceleroMetersForSession(@Param(value = "id") int id);

    @Modifying
    @Query(value = "delete from AcceleroMeter a where a.session.id =:id")
    void deleteForSession(@Param(value = "id") int id);
}
