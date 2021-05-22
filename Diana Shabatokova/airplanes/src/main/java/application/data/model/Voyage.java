package application.data.model;

import lombok.*;
import lombok.experimental.FieldDefaults;

import javax.persistence.*;
import javax.validation.constraints.Min;

@Entity
@Data
@FieldDefaults(level = AccessLevel.PRIVATE)
@AllArgsConstructor
@NoArgsConstructor
@Getter
@Setter
public class Voyage {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    Long id;

    @ManyToOne
    @JoinColumn(name = "from_id")
    Airport from;

    Long fromTS;

//    @Column
//    LocalDate fromDate;
//    @Column
//    LocalTime fromTime;

    @ManyToOne
    @JoinColumn(name = "to_id")
    Airport to;

//    @Column
//    LocalDate toDate;
//    @Column
//    LocalTime toTime;

    Long toTS;

    boolean baggagePassed;

    @Min(value = 0)
    Long price;

    @PrePersist
    public void toCreate() {
        setBaggagePassed(false);
    }
}
