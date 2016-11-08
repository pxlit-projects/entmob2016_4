package be.pxl.backend.services;

import be.pxl.backend.exceptions.SessionException;
import be.pxl.backend.jms.JmsSender;
import be.pxl.backend.models.AcceleroMeter;
import be.pxl.backend.models.Session;
import be.pxl.backend.models.Temperature;
import be.pxl.backend.repositories.*;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.expression.spel.ast.FloatLiteral;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.*;

/**
 * Created by Jonas on 14/10/16.
 */
@Service
public class SessionService {

    @Autowired
    private JmsSender jmsSender;

    @Autowired
    private HumidityRepository humidityRepository;

    @Autowired
    private AcceleroMeterRepository acceleroMeterRepository;

    @Autowired
    private PressureRepository pressureRepository;

    @Autowired
    private TemperatureRepository temperatureRepository;

    @Autowired
    private SessionRepository sessionRepository;

    public void setSessionRepository(SessionRepository sessionRepository) {
        this.sessionRepository = sessionRepository;
    }

    public Session startSession(Session session) {
        if (session.getStart() != null && session.getEnd() == null) {
            session = sessionRepository.save(session);
            jmsSender.sendMessage("start session with id:" + session.getId());
            return session;
        } else {
            SessionException sessionException = new SessionException("Session start cannot be null and Session end must be null!");
            jmsSender.sendMessage("start session:" + sessionException.getMessage());
            throw sessionException;
        }
    }

    public Session stopSession(Session session) {
        if (session.getStart() == null || session.getEnd() == null) {
            SessionException sessionException = new SessionException("Session start cannot be null and Session end cannot be null!");
            jmsSender.sendMessage("stop session:" + sessionException.getMessage());
            throw sessionException;
        } else if (session.getEnd().compareTo(session.getStart()) == 1) {
            SessionException sessionException = new SessionException("Session end must me after Session start");
            jmsSender.sendMessage("stop session:" + sessionException.getMessage());
            throw sessionException;
        } else {
            session = sessionRepository.save(session);
            return session;
        }
    }

    public Session getSessionById(int id) {
        Session session = sessionRepository.findOne(id);
        jmsSender.sendMessage("get session by id:" + id);
        return session;
    }

    public List<Session> getAllSessions(String username) {
        List<Session> sessions = sessionRepository.getAllSessions(username);
        jmsSender.sendMessage("get all sessions for user:" + username);
        return sessions;
    }

    @Transactional
    public void deleteSessionForId(int id) {
        pressureRepository.deleteForSession(id);
        temperatureRepository.deleteForSession(id);
        humidityRepository.deleteForSession(id);
        acceleroMeterRepository.deleteForSession(id);
        sessionRepository.delete(id);
    }

    public Map<String, Double> getAverages(int id) {
        Session session = getSessionById(id);
        Map<String, Double> dictionary = new HashMap<>();

        OptionalDouble avgTemp = session.getTemperatures().stream().mapToDouble(t -> t.getTemperature()).average();
        if (avgTemp.isPresent()) {
            dictionary.put("AverageTemperature", avgTemp.getAsDouble());
        }

        OptionalDouble avgHumidity = session.getHumidities().stream().mapToDouble(h -> h.getHumidity()).average();
        if(avgHumidity.isPresent()) {
            dictionary.put("AverageHumidity", avgHumidity.getAsDouble());
        }

        OptionalDouble avgPressure = session.getPressures().stream().mapToDouble(p -> p.getPressure()).average();
        if(avgPressure.isPresent()) {
            dictionary.put("AveragePressure", avgPressure.getAsDouble());
        }

        List<AcceleroMeter> acceleroMeters = session.getAcceleroMeters();
        double activity = activity(acceleroMeters);
        dictionary.put("AverageActivity", activity);

        jmsSender.sendMessage("get averages for session with id:" + id);
        return dictionary;
    }

    private double activity(List<AcceleroMeter> acceleroMeters) {
        double activity = 0.0;
        for(AcceleroMeter acceleroMeter: acceleroMeters) {
            double temp = 0.0;
        }
        return activity / (float)acceleroMeters.size();
    }

}
