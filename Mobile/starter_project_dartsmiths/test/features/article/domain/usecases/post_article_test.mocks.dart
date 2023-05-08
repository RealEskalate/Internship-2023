// Mocks generated by Mockito 5.4.0 from annotations
// in dartsmiths/test/features/article/domain/usecases/post_article_test.dart.
// Do not manually edit this file.

// ignore_for_file: no_leading_underscores_for_library_prefixes
import 'dart:async' as _i4;

import 'package:dartsmiths/core/error/failures.dart' as _i5;
import 'package:dartsmiths/features/article/domain/entities/article.dart'
    as _i6;
import 'package:dartsmiths/features/article/domain/repositories/article_repository.dart'
    as _i3;
import 'package:dartz/dartz.dart' as _i2;
import 'package:mockito/mockito.dart' as _i1;

// ignore_for_file: type=lint
// ignore_for_file: avoid_redundant_argument_values
// ignore_for_file: avoid_setters_without_getters
// ignore_for_file: comment_references
// ignore_for_file: implementation_imports
// ignore_for_file: invalid_use_of_visible_for_testing_member
// ignore_for_file: prefer_const_constructors
// ignore_for_file: unnecessary_parenthesis
// ignore_for_file: camel_case_types
// ignore_for_file: subtype_of_sealed_class

class _FakeEither_0<L, R> extends _i1.SmartFake implements _i2.Either<L, R> {
  _FakeEither_0(
    Object parent,
    Invocation parentInvocation,
  ) : super(
          parent,
          parentInvocation,
        );
}

/// A class which mocks [ArticleRepository].
///
/// See the documentation for Mockito's code generation for more information.
class MockArticleRepository extends _i1.Mock implements _i3.ArticleRepository {
  MockArticleRepository() {
    _i1.throwOnMissingStub(this);
  }

  @override
  _i4.Future<_i2.Either<_i5.Failure, _i6.Article>> postArticle(
          _i6.Article? article) =>
      (super.noSuchMethod(
        Invocation.method(
          #postArticle,
          [article],
        ),
        returnValue: _i4.Future<_i2.Either<_i5.Failure, _i6.Article>>.value(
            _FakeEither_0<_i5.Failure, _i6.Article>(
          this,
          Invocation.method(
            #postArticle,
            [article],
          ),
        )),
      ) as _i4.Future<_i2.Either<_i5.Failure, _i6.Article>>);
  @override
  _i4.Future<_i2.Either<_i5.Failure, _i6.Article>> updateArticle(
          _i6.Article? article) =>
      (super.noSuchMethod(
        Invocation.method(
          #updateArticle,
          [article],
        ),
        returnValue: _i4.Future<_i2.Either<_i5.Failure, _i6.Article>>.value(
            _FakeEither_0<_i5.Failure, _i6.Article>(
          this,
          Invocation.method(
            #updateArticle,
            [article],
          ),
        )),
      ) as _i4.Future<_i2.Either<_i5.Failure, _i6.Article>>);
}
