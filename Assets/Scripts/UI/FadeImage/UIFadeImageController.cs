using System;
using System.Collections;
using UnityEngine;

public class UIFadeImageController
{
  readonly SceneObjectMonoBehaviour model;
  readonly UIFadeImageView view;
  public UIFadeImageController(UIFadeImageView view, SceneObjectMonoBehaviour model)
  {
    this.view = view;
    this.model = model;
  }

  public void Enable()
  {
    model.OnBeforeSceneChange += OnBeforeSceneChangeHandler;
    model.OnAfterSceneChange += OnAftereSceneChangeHandler;
  }

  private IEnumerator OnBeforeSceneChangeHandler(SceneModel instance)
  {
    view.SetColor(Color.black);
    yield return new WaitForSeconds(1);
  }

  private IEnumerator OnAftereSceneChangeHandler(SceneModel instance)
  {
    yield return new WaitUntil(() => true);
    view.SetColor(new Color(0, 0, 0, 0));
  }



  public void Disable()
  {
    model.OnBeforeSceneChange -= OnBeforeSceneChangeHandler;
    model.OnAfterSceneChange -= OnAftereSceneChangeHandler;
  }
}