import 'package:flutter/material.dart';
import '../widgets/content_widget.dart';
import '../widgets/publish_button.dart';
import '../widgets/input_field.dart';

class ArticleFormPage extends StatelessWidget {
  const ArticleFormPage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    final Size screenSize = MediaQuery.of(context).size;

    return Scaffold(
      appBar: AppBar(
        elevation: 0,
        backgroundColor: Colors.white,
        leading: IconButton(
          icon: const Icon(Icons.arrow_back, color: Colors.black),
          onPressed: () {},
        ),
        title: const Text(
          'New Article',
          style: TextStyle(color: Colors.black),
          textAlign: TextAlign.center,
        ),
        centerTitle: true,
      ),
      body: Padding(
        padding: const EdgeInsets.all(10.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            SizedBox(
              height: screenSize.height * 0.02,
            ),
            const InputField(labelText: 'Add Title'),
            SizedBox(height: screenSize.height * 0.01),
            const InputField(labelText: 'Add Subtitle'),
            SizedBox(height: screenSize.height * 0.01),
             Row(
              children: [
                const Expanded(
                    child: InputField(labelText: 'Add Tags'),
                  ),
                  IconButton( onPressed: () {}, icon: const Icon(Icons.add),
                ),
              ],
            ),
            SizedBox(height: screenSize.height * 0.01),
            Text(
              'Add as many tags as you want',
              textAlign: TextAlign.start,
              style: TextStyle(fontSize: screenSize.height * 0.02),
            ),
            SizedBox(height: screenSize.height * 0.05),
            const ContentFormField(),
            SizedBox(height: screenSize.height * 0.05),
            const PublishButton(),
          ],
        ),
      ),
    );
  }
}