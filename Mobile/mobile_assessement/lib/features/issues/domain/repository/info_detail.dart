import 'package:dartz/dartz.dart';
import '../../../../core/error/failures.dart';
import '../entities/info_detail.dart';

abstract class InfoRepository {
  
  Future<Either<Failure, InfoDetail>> getInfoDetail(String id);
  Future<Either<Failure, InfoDetail>> getAllInfo();
}
