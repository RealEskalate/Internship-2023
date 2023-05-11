import 'dart:async' as _i4;

import 'package:dartz/dartz.dart' as _i2;
import 'package:matador/core/error/failures.dart' as _i5;
import 'package:matador/features/signup/domain/entities/user.dart' as _i6;
import 'package:matador/features/signup/domain/repositories/auth_repository.dart'
    as _i3;
import 'package:mockito/mockito.dart' as _i1;

class _FakeEither_0<L, R> extends _i1.SmartFake implements _i2.Either<L, R> {
  _FakeEither_0(
    Object parent,
    Invocation parentInvocation,
  ) : super(
          parent,
          parentInvocation,
        );
}

class MockAuthRepository extends _i1.Mock implements _i3.AuthRepository {
  MockAuthRepository() {
    _i1.throwOnMissingStub(this);
  }

  @override
  _i4.Future<_i2.Either<_i5.Failure, _i6.User>> signUp(
    String? email,
    String? password,
  ) =>
      (super.noSuchMethod(
        Invocation.method(
          #signUp,
          [
            email,
            password,
          ],
        ),
        returnValue: _i4.Future<_i2.Either<_i5.Failure, _i6.User>>.value(
            _FakeEither_0<_i5.Failure, _i6.User>(
          this,
          Invocation.method(
            #signUp,
            [
              email,
              password,
            ],
          ),
        )),
      ) as _i4.Future<_i2.Either<_i5.Failure, _i6.User>>);
}
