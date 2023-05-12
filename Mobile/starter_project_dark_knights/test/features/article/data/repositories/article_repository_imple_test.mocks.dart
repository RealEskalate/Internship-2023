// Mocks generated by Mockito 5.4.0 from annotations
// in dark_knights/test/features/article/data/repositories/article_repository_imple_test.dart.
// Do not manually edit this file.

// ignore_for_file: no_leading_underscores_for_library_prefixes
import 'dart:async' as _i4;

import 'package:dark_knights/core/network/network_info.dart' as _i7;
import 'package:dark_knights/features/article/data/datasources/article_local_data_source.dart'
    as _i6;
import 'package:dark_knights/features/article/data/datasources/article_remote_data_source.dart'
    as _i3;
import 'package:dark_knights/features/article/data/models/article_model.dart'
    as _i2;
import 'package:dark_knights/features/article/domain/entities/article.dart'
    as _i5;
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

class _FakeArticleModel_0 extends _i1.SmartFake implements _i2.ArticleModel {
  _FakeArticleModel_0(
    Object parent,
    Invocation parentInvocation,
  ) : super(
          parent,
          parentInvocation,
        );
}

/// A class which mocks [ArticleRemoteDataSource].
///
/// See the documentation for Mockito's code generation for more information.
class MockArticleRemoteDataSource extends _i1.Mock
    implements _i3.ArticleRemoteDataSource {
  MockArticleRemoteDataSource() {
    _i1.throwOnMissingStub(this);
  }

  @override
  _i4.Future<_i2.ArticleModel> deleteArticle(String? id) => (super.noSuchMethod(
        Invocation.method(
          #deleteArticle,
          [id],
        ),
        returnValue: _i4.Future<_i2.ArticleModel>.value(_FakeArticleModel_0(
          this,
          Invocation.method(
            #deleteArticle,
            [id],
          ),
        )),
      ) as _i4.Future<_i2.ArticleModel>);
  @override
  _i4.Future<_i2.ArticleModel> getArticleById(String? id) =>
      (super.noSuchMethod(
        Invocation.method(
          #getArticleById,
          [id],
        ),
        returnValue: _i4.Future<_i2.ArticleModel>.value(_FakeArticleModel_0(
          this,
          Invocation.method(
            #getArticleById,
            [id],
          ),
        )),
      ) as _i4.Future<_i2.ArticleModel>);
  @override
  _i4.Future<List<_i2.ArticleModel>> getArticles() => (super.noSuchMethod(
        Invocation.method(
          #getArticles,
          [],
        ),
        returnValue:
            _i4.Future<List<_i2.ArticleModel>>.value(<_i2.ArticleModel>[]),
      ) as _i4.Future<List<_i2.ArticleModel>>);
  @override
  _i4.Future<List<_i2.ArticleModel>> getArticlesByUserId(String? userId) =>
      (super.noSuchMethod(
        Invocation.method(
          #getArticlesByUserId,
          [userId],
        ),
        returnValue:
            _i4.Future<List<_i2.ArticleModel>>.value(<_i2.ArticleModel>[]),
      ) as _i4.Future<List<_i2.ArticleModel>>);
  @override
  _i4.Future<_i2.ArticleModel> postArticle(_i5.Article? article) =>
      (super.noSuchMethod(
        Invocation.method(
          #postArticle,
          [article],
        ),
        returnValue: _i4.Future<_i2.ArticleModel>.value(_FakeArticleModel_0(
          this,
          Invocation.method(
            #postArticle,
            [article],
          ),
        )),
      ) as _i4.Future<_i2.ArticleModel>);
  @override
  _i4.Future<_i2.ArticleModel> updateArticle(
    String? id,
    _i5.Article? article,
  ) =>
      (super.noSuchMethod(
        Invocation.method(
          #updateArticle,
          [
            id,
            article,
          ],
        ),
        returnValue: _i4.Future<_i2.ArticleModel>.value(_FakeArticleModel_0(
          this,
          Invocation.method(
            #updateArticle,
            [
              id,
              article,
            ],
          ),
        )),
      ) as _i4.Future<_i2.ArticleModel>);
}

/// A class which mocks [ArticleLocalDataSource].
///
/// See the documentation for Mockito's code generation for more information.
class MockArticleLocalDataSource extends _i1.Mock
    implements _i6.ArticleLocalDataSource {
  MockArticleLocalDataSource() {
    _i1.throwOnMissingStub(this);
  }

  @override
  _i4.Future<List<_i2.ArticleModel>> getLastArticles() => (super.noSuchMethod(
        Invocation.method(
          #getLastArticles,
          [],
        ),
        returnValue:
            _i4.Future<List<_i2.ArticleModel>>.value(<_i2.ArticleModel>[]),
      ) as _i4.Future<List<_i2.ArticleModel>>);
  @override
  _i4.Future<void> cacheArticles(List<_i2.ArticleModel>? articles) =>
      (super.noSuchMethod(
        Invocation.method(
          #cacheArticles,
          [articles],
        ),
        returnValue: _i4.Future<void>.value(),
        returnValueForMissingStub: _i4.Future<void>.value(),
      ) as _i4.Future<void>);
}

/// A class which mocks [NetworkInfo].
///
/// See the documentation for Mockito's code generation for more information.
class MockNetworkInfo extends _i1.Mock implements _i7.NetworkInfo {
  MockNetworkInfo() {
    _i1.throwOnMissingStub(this);
  }

  @override
  _i4.Future<bool> get isConnected => (super.noSuchMethod(
        Invocation.getter(#isConnected),
        returnValue: _i4.Future<bool>.value(false),
      ) as _i4.Future<bool>);
}