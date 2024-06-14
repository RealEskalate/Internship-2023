import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';
import 'package:mobile_assessement/features/issues/domain/entities/info_detail.dart';
import '../../../../core/error/failures.dart';
import '../../../../core/usecases/usecase.dart';
import '../repository/info_detail.dart';

class GetInfoDetail implements UseCase<InfoDetail, Params> {
  final InfoRepository repository;

  GetInfoDetail(this.repository);

  @override
  Future<Either<Failure, InfoDetail>> call(Params params) async {
    return await repository.getInfoDetail(params.id);
  }
}

class Params extends Equatable {
  final String id;

  Params({required this.id});

  @override
  List<Object?> get props => [id];
}
