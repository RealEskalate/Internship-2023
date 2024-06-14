import 'package:dartz/dartz.dart';
import 'package:mobile_assessement/features/issues/domain/entities/info_detail.dart';
import '../../../../core/error/failures.dart';
import '../../../../core/usecases/usecase.dart';
import '../repository/info_detail.dart';

class GetAllInfoDetail implements UseCase<InfoDetail, NoParams> {
  final InfoRepository repository;

  GetAllInfoDetail(this.repository);

  @override
  Future<Either<Failure, InfoDetail>> call(NoParams noParams) async {
    return await repository.getAllInfo();
  }
}
