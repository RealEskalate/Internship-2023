import 'package:dartz/dartz.dart';
import 'package:mobile_assessement/features/feed/detail/domain/entity/detail.dart';

import '../../../../../core/error/failures.dart';

abstract class HomeDetailRepository {

  
  Future<Either<Failure, HomeDetail>> getWeather(String city);
}