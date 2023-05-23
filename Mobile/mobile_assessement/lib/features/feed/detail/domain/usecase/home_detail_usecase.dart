import 'package:dartz/dartz.dart';
import 'package:flutter/material.dart';
import 'package:mobile_assessement/features/feed/detail/domain/entity/detail.dart';
import 'package:mobile_assessement/features/feed/detail/domain/repository/home_detail_repository.dart';

import '../../../../../core/error/failures.dart';
import '../../../../../core/usecases/usecase.dart';

class GetWeather implements UseCase<HomeDetail, String> {
  final HomeDetailRepository repository;

  GetWeather(this.repository);

  @override
  Future<Either<Failure, HomeDetail>> call(city) async {
    return await repository.getWeather(city);
  }
}
