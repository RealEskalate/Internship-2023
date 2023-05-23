import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';
import 'package:mobile_assessement/features/feed/detail/domain/entity/detail.dart';
import 'package:mobile_assessement/features/feed/detail/domain/usecase/home_detail_usecase.dart';

part 'detail_event.dart';
part 'detail_state.dart';

class DetailBloc extends Bloc<DetailEvent, DetailState> {
  final GetWeather getWeather;
  DetailBloc({required this.getWeather}) : super(DetailInitial()) {
    on<DetailEvent>((event, emit) {
      emit(DetailLoading());
    });
     on<GetWeatherEvent>((event, emit) async {
      
      try {
        emit(DetailLoading());
        final homeDetail = await getWeather(event.city);
        emit(DetailSuccess(homeDetail: homeDetail as HomeDetail));
        
      } catch (e) {
        emit(DetailFailure(error: e as Error));
      }

    });

  }
 
  // }
}
