﻿// Decompiled with JetBrains decompiler
// Type: UnityEditor.TextureImporterInspector
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01B28312-B6F5-4E06-90F6-BE297B711E41
// Assembly location: C:\Users\Blake\sandbox\unity\test-project\Library\UnityAssemblies\UnityEditor.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.AnimatedValues;
using UnityEngine;
using UnityEngine.Events;

namespace UnityEditor
{
  [CustomEditor(typeof (TextureImporter))]
  [CanEditMultipleObjects]
  internal class TextureImporterInspector : AssetImporterInspector
  {
    private static readonly int[] kTextureFormatsValueWeb = new int[9]{ 10, 12, 28, 29, 7, 3, 1, 2, 5 };
    private static readonly int[] kTextureFormatsValueWiiU = new int[6]{ 10, 12, 7, 1, 4, 13 };
    private static readonly int[] kTextureFormatsValueiPhone = new int[9]{ 30, 31, 32, 33, 7, 3, 1, 13, 4 };
    private static readonly int[] kTextureFormatsValuetvOS = new int[21]{ 30, 31, 32, 33, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 7, 3, 1, 13, 4 };
    private static readonly int[] kTextureFormatsValueAndroid = new int[31]{ 10, 12, 28, 29, 34, 45, 46, 47, 30, 31, 32, 33, 35, 36, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 7, 3, 1, 13, 4 };
    private static readonly int[] kTextureFormatsValueBB10 = new int[10]{ 34, 30, 31, 32, 33, 7, 3, 1, 13, 4 };
    private static readonly int[] kTextureFormatsValueTizen = new int[6]{ 34, 7, 3, 1, 13, 4 };
    private static readonly int[] kTextureFormatsValueSTV = new int[6]{ 34, 7, 3, 1, 13, 4 };
    private static readonly int[] kTextureFormatsValueGLESEmu = new int[25]{ 34, 30, 31, 32, 33, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 7, 3, 1, 13, 5 };
    private static readonly int[] kNormalFormatsValueWeb = new int[4]{ 12, 29, 2, 5 };
    private static readonly TextureImporterFormat[] kFormatsWithCompressionSettings = new TextureImporterFormat[24]{ TextureImporterFormat.DXT1Crunched, TextureImporterFormat.DXT5Crunched, TextureImporterFormat.PVRTC_RGB2, TextureImporterFormat.PVRTC_RGB4, TextureImporterFormat.PVRTC_RGBA2, TextureImporterFormat.PVRTC_RGBA4, TextureImporterFormat.ATC_RGB4, TextureImporterFormat.ATC_RGBA8, TextureImporterFormat.ETC_RGB4, TextureImporterFormat.ETC2_RGB4, TextureImporterFormat.ETC2_RGB4_PUNCHTHROUGH_ALPHA, TextureImporterFormat.ETC2_RGBA8, TextureImporterFormat.ASTC_RGB_4x4, TextureImporterFormat.ASTC_RGB_5x5, TextureImporterFormat.ASTC_RGB_6x6, TextureImporterFormat.ASTC_RGB_8x8, TextureImporterFormat.ASTC_RGB_10x10, TextureImporterFormat.ASTC_RGB_12x12, TextureImporterFormat.ASTC_RGBA_4x4, TextureImporterFormat.ASTC_RGBA_5x5, TextureImporterFormat.ASTC_RGBA_6x6, TextureImporterFormat.ASTC_RGBA_8x8, TextureImporterFormat.ASTC_RGBA_10x10, TextureImporterFormat.ASTC_RGBA_12x12 };
    private static readonly string[] kMaxTextureSizeStrings = new string[9]{ "32", "64", "128", "256", "512", "1024", "2048", "4096", "8192" };
    private static readonly int[] kMaxTextureSizeValues = new int[9]{ 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192 };
    private readonly AnimBool m_ShowBumpGenerationSettings = new AnimBool();
    private readonly AnimBool m_ShowCookieCubeMapSettings = new AnimBool();
    private readonly AnimBool m_ShowConvolutionCubeMapSettings = new AnimBool();
    private readonly AnimBool m_ShowGenericSpriteSettings = new AnimBool();
    private readonly AnimBool m_ShowManualAtlasGenerationSettings = new AnimBool();
    private readonly GUIContent m_EmptyContent = new GUIContent(" ");
    private readonly int[] m_TextureTypeValues = new int[9]{ 0, 1, 2, 8, 7, 3, 4, 6, 5 };
    private readonly int[] m_TextureFormatValues = new int[4]{ 0, 1, 2, 4 };
    private readonly int[] m_FilterModeOptions = (int[]) Enum.GetValues(typeof (UnityEngine.FilterMode));
    private SerializedProperty m_TextureType;
    [SerializeField]
    protected List<TextureImporterInspector.PlatformSetting> m_PlatformSettings;
    private static int[] s_TextureFormatsValueAll;
    private static int[] s_NormalFormatsValueAll;
    private static string[] s_TextureFormatStringsAll;
    private static string[] s_TextureFormatStringsWiiU;
    private static string[] s_TextureFormatStringsGLESEmu;
    private static string[] s_TextureFormatStringsiPhone;
    private static string[] s_TextureFormatStringstvOS;
    private static string[] s_TextureFormatStringsAndroid;
    private static string[] s_TextureFormatStringsBB10;
    private static string[] s_TextureFormatStringsTizen;
    private static string[] s_TextureFormatStringsSTV;
    private static string[] s_TextureFormatStringsWeb;
    private static string[] s_NormalFormatStringsAll;
    private static string[] s_NormalFormatStringsWeb;
    private string m_ImportWarning;
    private static TextureImporterInspector.Styles s_Styles;
    private SerializedProperty m_GrayscaleToAlpha;
    private SerializedProperty m_ConvertToNormalMap;
    private SerializedProperty m_NormalMap;
    private SerializedProperty m_HeightScale;
    private SerializedProperty m_NormalMapFilter;
    private SerializedProperty m_GenerateCubemap;
    private SerializedProperty m_CubemapConvolution;
    private SerializedProperty m_CubemapConvolutionSteps;
    private SerializedProperty m_CubemapConvolutionExponent;
    private SerializedProperty m_SeamlessCubemap;
    private SerializedProperty m_BorderMipMap;
    private SerializedProperty m_NPOTScale;
    private SerializedProperty m_IsReadable;
    private SerializedProperty m_LinearTexture;
    private SerializedProperty m_RGBM;
    private SerializedProperty m_EnableMipMap;
    private SerializedProperty m_GenerateMipsInLinearSpace;
    private SerializedProperty m_MipMapMode;
    private SerializedProperty m_FadeOut;
    private SerializedProperty m_MipMapFadeDistanceStart;
    private SerializedProperty m_MipMapFadeDistanceEnd;
    private SerializedProperty m_Lightmap;
    private SerializedProperty m_Aniso;
    private SerializedProperty m_FilterMode;
    private SerializedProperty m_WrapMode;
    private SerializedProperty m_SpriteMode;
    private SerializedProperty m_SpritePackingTag;
    private SerializedProperty m_SpritePixelsToUnits;
    private SerializedProperty m_SpriteExtrude;
    private SerializedProperty m_SpriteMeshType;
    private SerializedProperty m_Alignment;
    private SerializedProperty m_SpritePivot;
    private SerializedProperty m_AlphaIsTransparency;

    private TextureImporterType textureType
    {
      get
      {
        if (this.textureTypeHasMultipleDifferentValues)
          return ~TextureImporterType.Image;
        if (this.m_TextureType.intValue < 0)
          return (this.target as TextureImporter).textureType;
        return (TextureImporterType) this.m_TextureType.intValue;
      }
    }

    private bool textureTypeHasMultipleDifferentValues
    {
      get
      {
        if (this.m_TextureType.hasMultipleDifferentValues)
          return true;
        if (this.m_TextureType.intValue >= 0)
          return false;
        TextureImporterType textureType = (this.target as TextureImporter).textureType;
        foreach (UnityEngine.Object target in this.targets)
        {
          if ((target as TextureImporter).textureType != textureType)
            return true;
        }
        return false;
      }
    }

    internal override bool showImportedObject
    {
      get
      {
        return false;
      }
    }

    private static int[] TextureFormatsValueAll
    {
      get
      {
        if (TextureImporterInspector.s_TextureFormatsValueAll != null)
          return TextureImporterInspector.s_TextureFormatsValueAll;
        bool flag1 = false;
        bool flag2 = false;
        bool flag3 = false;
        bool flag4 = false;
        bool flag5 = false;
        foreach (BuildPlayerWindow.BuildPlatform playerValidPlatform in TextureImporterInspector.GetBuildPlayerValidPlatforms())
        {
          BuildTarget defaultTarget = playerValidPlatform.DefaultTarget;
          switch (defaultTarget)
          {
            case BuildTarget.iOS:
              flag2 = true;
              break;
            case BuildTarget.Android:
              flag2 = true;
              flag1 = true;
              flag3 = true;
              flag4 = true;
              flag5 = true;
              break;
            case BuildTarget.StandaloneGLESEmu:
              flag2 = true;
              flag1 = true;
              flag4 = true;
              flag5 = true;
              break;
            default:
              switch (defaultTarget - 34)
              {
                case ~BuildTarget.iPhone:
                  flag1 = true;
                  continue;
                case (BuildTarget) 3:
                  flag2 = true;
                  flag5 = true;
                  continue;
                default:
                  if (defaultTarget != BuildTarget.BlackBerry)
                  {
                    if (defaultTarget == BuildTarget.Tizen)
                    {
                      flag1 = true;
                      continue;
                    }
                    continue;
                  }
                  flag2 = true;
                  flag1 = true;
                  continue;
              }
          }
        }
        List<int> intList = new List<int>();
        intList.AddRange((IEnumerable<int>) new int[3]{ -1, 10, 12 });
        if (flag1)
          intList.Add(34);
        if (flag2)
          intList.AddRange((IEnumerable<int>) new int[4]{ 30, 31, 32, 33 });
        if (flag3)
          intList.AddRange((IEnumerable<int>) new int[2]{ 35, 36 });
        if (flag4)
          intList.AddRange((IEnumerable<int>) new int[3]{ 45, 46, 47 });
        if (flag5)
          intList.AddRange((IEnumerable<int>) new int[12]
          {
            48,
            49,
            50,
            51,
            52,
            53,
            54,
            55,
            56,
            57,
            58,
            59
          });
        intList.AddRange((IEnumerable<int>) new int[12]
        {
          -2,
          7,
          2,
          13,
          -3,
          3,
          1,
          5,
          4,
          -5,
          28,
          29
        });
        TextureImporterInspector.s_TextureFormatsValueAll = intList.ToArray();
        return TextureImporterInspector.s_TextureFormatsValueAll;
      }
    }

    private static int[] NormalFormatsValueAll
    {
      get
      {
        bool flag1 = false;
        bool flag2 = false;
        bool flag3 = false;
        bool flag4 = false;
        bool flag5 = false;
        foreach (BuildPlayerWindow.BuildPlatform playerValidPlatform in TextureImporterInspector.GetBuildPlayerValidPlatforms())
        {
          BuildTarget defaultTarget = playerValidPlatform.DefaultTarget;
          switch (defaultTarget)
          {
            case BuildTarget.iOS:
              flag2 = true;
              flag1 = true;
              break;
            case BuildTarget.Android:
              flag2 = true;
              flag3 = true;
              flag1 = true;
              flag4 = true;
              flag5 = true;
              break;
            case BuildTarget.StandaloneGLESEmu:
              flag2 = true;
              flag1 = true;
              flag4 = true;
              flag5 = true;
              break;
            default:
              if (defaultTarget != BuildTarget.BlackBerry)
              {
                if (defaultTarget != BuildTarget.Tizen)
                {
                  if (defaultTarget == BuildTarget.tvOS)
                  {
                    flag2 = true;
                    flag1 = true;
                    flag5 = true;
                    break;
                  }
                  break;
                }
                flag1 = true;
                break;
              }
              flag2 = true;
              flag1 = true;
              break;
          }
        }
        List<int> intList = new List<int>();
        intList.AddRange((IEnumerable<int>) new int[2]{ -1, 12 });
        if (flag2)
          intList.AddRange((IEnumerable<int>) new int[4]{ 30, 31, 32, 33 });
        if (flag3)
          intList.AddRange((IEnumerable<int>) new int[2]{ 35, 36 });
        if (flag1)
          intList.AddRange((IEnumerable<int>) new int[1]{ 34 });
        if (flag4)
          intList.AddRange((IEnumerable<int>) new int[3]{ 45, 46, 47 });
        if (flag5)
          intList.AddRange((IEnumerable<int>) new int[12]
          {
            48,
            49,
            50,
            51,
            52,
            53,
            54,
            55,
            56,
            57,
            58,
            59
          });
        intList.AddRange((IEnumerable<int>) new int[7]
        {
          -2,
          2,
          13,
          -3,
          4,
          -5,
          29
        });
        TextureImporterInspector.s_NormalFormatsValueAll = intList.ToArray();
        return TextureImporterInspector.s_NormalFormatsValueAll;
      }
    }

    public new void OnDisable()
    {
      base.OnDisable();
    }

    internal static bool IsGLESMobileTargetPlatform(BuildTarget target)
    {
      if (target != BuildTarget.iOS && target != BuildTarget.Android && (target != BuildTarget.BlackBerry && target != BuildTarget.Tizen) && target != BuildTarget.SamsungTV)
        return target == BuildTarget.tvOS;
      return true;
    }

    private void UpdateImportWarning()
    {
      TextureImporter target = this.target as TextureImporter;
      this.m_ImportWarning = !(bool) ((UnityEngine.Object) target) ? (string) null : target.GetImportWarnings();
    }

    private void ToggleFromInt(SerializedProperty property, GUIContent label)
    {
      EditorGUI.BeginChangeCheck();
      EditorGUI.showMixedValue = property.hasMultipleDifferentValues;
      int num = !EditorGUILayout.Toggle(label, property.intValue > 0, new GUILayoutOption[0]) ? 0 : 1;
      EditorGUI.showMixedValue = false;
      if (!EditorGUI.EndChangeCheck())
        return;
      property.intValue = num;
    }

    private void EnumPopup(SerializedProperty property, System.Type type, GUIContent label)
    {
      EditorGUILayout.IntPopup(property, EditorGUIUtility.TempContent(Enum.GetNames(type)), Enum.GetValues(type) as int[], label, new GUILayoutOption[0]);
    }

    private void CacheSerializedProperties()
    {
      this.m_TextureType = this.serializedObject.FindProperty("m_TextureType");
      this.m_GrayscaleToAlpha = this.serializedObject.FindProperty("m_GrayScaleToAlpha");
      this.m_ConvertToNormalMap = this.serializedObject.FindProperty("m_ConvertToNormalMap");
      this.m_NormalMap = this.serializedObject.FindProperty("m_ExternalNormalMap");
      this.m_HeightScale = this.serializedObject.FindProperty("m_HeightScale");
      this.m_NormalMapFilter = this.serializedObject.FindProperty("m_NormalMapFilter");
      this.m_GenerateCubemap = this.serializedObject.FindProperty("m_GenerateCubemap");
      this.m_SeamlessCubemap = this.serializedObject.FindProperty("m_SeamlessCubemap");
      this.m_BorderMipMap = this.serializedObject.FindProperty("m_BorderMipMap");
      this.m_NPOTScale = this.serializedObject.FindProperty("m_NPOTScale");
      this.m_IsReadable = this.serializedObject.FindProperty("m_IsReadable");
      this.m_LinearTexture = this.serializedObject.FindProperty("m_LinearTexture");
      this.m_RGBM = this.serializedObject.FindProperty("m_RGBM");
      this.m_EnableMipMap = this.serializedObject.FindProperty("m_EnableMipMap");
      this.m_MipMapMode = this.serializedObject.FindProperty("m_MipMapMode");
      this.m_GenerateMipsInLinearSpace = this.serializedObject.FindProperty("correctGamma");
      this.m_FadeOut = this.serializedObject.FindProperty("m_FadeOut");
      this.m_MipMapFadeDistanceStart = this.serializedObject.FindProperty("m_MipMapFadeDistanceStart");
      this.m_MipMapFadeDistanceEnd = this.serializedObject.FindProperty("m_MipMapFadeDistanceEnd");
      this.m_Lightmap = this.serializedObject.FindProperty("m_Lightmap");
      this.m_Aniso = this.serializedObject.FindProperty("m_TextureSettings.m_Aniso");
      this.m_FilterMode = this.serializedObject.FindProperty("m_TextureSettings.m_FilterMode");
      this.m_WrapMode = this.serializedObject.FindProperty("m_TextureSettings.m_WrapMode");
      this.m_CubemapConvolution = this.serializedObject.FindProperty("m_CubemapConvolution");
      this.m_CubemapConvolutionSteps = this.serializedObject.FindProperty("m_CubemapConvolutionSteps");
      this.m_CubemapConvolutionExponent = this.serializedObject.FindProperty("m_CubemapConvolutionExponent");
      this.m_SpriteMode = this.serializedObject.FindProperty("m_SpriteMode");
      this.m_SpritePackingTag = this.serializedObject.FindProperty("m_SpritePackingTag");
      this.m_SpritePixelsToUnits = this.serializedObject.FindProperty("m_SpritePixelsToUnits");
      this.m_SpriteExtrude = this.serializedObject.FindProperty("m_SpriteExtrude");
      this.m_SpriteMeshType = this.serializedObject.FindProperty("m_SpriteMeshType");
      this.m_Alignment = this.serializedObject.FindProperty("m_Alignment");
      this.m_SpritePivot = this.serializedObject.FindProperty("m_SpritePivot");
      this.m_AlphaIsTransparency = this.serializedObject.FindProperty("m_AlphaIsTransparency");
    }

    public virtual void OnEnable()
    {
      this.CacheSerializedProperties();
      this.m_ShowBumpGenerationSettings.valueChanged.AddListener(new UnityAction(((Editor) this).Repaint));
      this.m_ShowCookieCubeMapSettings.valueChanged.AddListener(new UnityAction(((Editor) this).Repaint));
      this.m_ShowCookieCubeMapSettings.value = this.textureType == TextureImporterType.Cookie && this.m_GenerateCubemap.intValue != 0;
      this.m_ShowConvolutionCubeMapSettings.value = this.m_CubemapConvolution.intValue == 1 && this.m_GenerateCubemap.intValue != 0;
      this.m_ShowGenericSpriteSettings.valueChanged.AddListener(new UnityAction(((Editor) this).Repaint));
      this.m_ShowManualAtlasGenerationSettings.valueChanged.AddListener(new UnityAction(((Editor) this).Repaint));
      this.m_ShowGenericSpriteSettings.value = this.m_SpriteMode.intValue != 0;
      this.m_ShowManualAtlasGenerationSettings.value = this.m_SpriteMode.intValue == 2;
    }

    private void SetSerializedPropertySettings(TextureImporterSettings settings)
    {
      this.m_GrayscaleToAlpha.intValue = !settings.grayscaleToAlpha ? 0 : 1;
      this.m_ConvertToNormalMap.intValue = !settings.convertToNormalMap ? 0 : 1;
      this.m_NormalMap.intValue = !settings.normalMap ? 0 : 1;
      this.m_HeightScale.floatValue = settings.heightmapScale;
      this.m_NormalMapFilter.intValue = (int) settings.normalMapFilter;
      this.m_GenerateCubemap.intValue = (int) settings.generateCubemap;
      this.m_CubemapConvolution.intValue = (int) settings.cubemapConvolution;
      this.m_CubemapConvolutionSteps.intValue = settings.cubemapConvolutionSteps;
      this.m_CubemapConvolutionExponent.floatValue = settings.cubemapConvolutionExponent;
      this.m_SeamlessCubemap.intValue = !settings.seamlessCubemap ? 0 : 1;
      this.m_BorderMipMap.intValue = !settings.borderMipmap ? 0 : 1;
      this.m_NPOTScale.intValue = (int) settings.npotScale;
      this.m_IsReadable.intValue = !settings.readable ? 0 : 1;
      this.m_EnableMipMap.intValue = !settings.mipmapEnabled ? 0 : 1;
      this.m_LinearTexture.intValue = !settings.linearTexture ? 0 : 1;
      this.m_RGBM.intValue = (int) settings.rgbm;
      this.m_MipMapMode.intValue = (int) settings.mipmapFilter;
      this.m_GenerateMipsInLinearSpace.intValue = !settings.generateMipsInLinearSpace ? 0 : 1;
      this.m_FadeOut.intValue = !settings.fadeOut ? 0 : 1;
      this.m_MipMapFadeDistanceStart.intValue = settings.mipmapFadeDistanceStart;
      this.m_MipMapFadeDistanceEnd.intValue = settings.mipmapFadeDistanceEnd;
      this.m_Lightmap.intValue = !settings.lightmap ? 0 : 1;
      this.m_SpriteMode.intValue = settings.spriteMode;
      this.m_SpritePixelsToUnits.floatValue = settings.spritePixelsPerUnit;
      this.m_SpriteExtrude.intValue = (int) settings.spriteExtrude;
      this.m_SpriteMeshType.intValue = (int) settings.spriteMeshType;
      this.m_Alignment.intValue = settings.spriteAlignment;
      this.m_WrapMode.intValue = (int) settings.wrapMode;
      this.m_FilterMode.intValue = (int) settings.filterMode;
      this.m_Aniso.intValue = settings.aniso;
      this.m_AlphaIsTransparency.intValue = !settings.alphaIsTransparency ? 0 : 1;
    }

    private TextureImporterSettings GetSerializedPropertySettings()
    {
      return this.GetSerializedPropertySettings(new TextureImporterSettings());
    }

    private TextureImporterSettings GetSerializedPropertySettings(TextureImporterSettings settings)
    {
      if (!this.m_GrayscaleToAlpha.hasMultipleDifferentValues)
        settings.grayscaleToAlpha = this.m_GrayscaleToAlpha.intValue > 0;
      if (!this.m_ConvertToNormalMap.hasMultipleDifferentValues)
        settings.convertToNormalMap = this.m_ConvertToNormalMap.intValue > 0;
      if (!this.m_NormalMap.hasMultipleDifferentValues)
        settings.normalMap = this.m_NormalMap.intValue > 0;
      if (!this.m_HeightScale.hasMultipleDifferentValues)
        settings.heightmapScale = this.m_HeightScale.floatValue;
      if (!this.m_NormalMapFilter.hasMultipleDifferentValues)
        settings.normalMapFilter = (TextureImporterNormalFilter) this.m_NormalMapFilter.intValue;
      if (!this.m_GenerateCubemap.hasMultipleDifferentValues)
        settings.generateCubemap = (TextureImporterGenerateCubemap) this.m_GenerateCubemap.intValue;
      if (!this.m_CubemapConvolution.hasMultipleDifferentValues)
        settings.cubemapConvolution = (TextureImporterCubemapConvolution) this.m_CubemapConvolution.intValue;
      if (!this.m_CubemapConvolutionSteps.hasMultipleDifferentValues)
        settings.cubemapConvolutionSteps = this.m_CubemapConvolutionSteps.intValue;
      if (!this.m_CubemapConvolutionExponent.hasMultipleDifferentValues)
        settings.cubemapConvolutionExponent = this.m_CubemapConvolutionExponent.floatValue;
      if (!this.m_SeamlessCubemap.hasMultipleDifferentValues)
        settings.seamlessCubemap = this.m_SeamlessCubemap.intValue > 0;
      if (!this.m_BorderMipMap.hasMultipleDifferentValues)
        settings.borderMipmap = this.m_BorderMipMap.intValue > 0;
      if (!this.m_NPOTScale.hasMultipleDifferentValues)
        settings.npotScale = (TextureImporterNPOTScale) this.m_NPOTScale.intValue;
      if (!this.m_IsReadable.hasMultipleDifferentValues)
        settings.readable = this.m_IsReadable.intValue > 0;
      if (!this.m_LinearTexture.hasMultipleDifferentValues)
        settings.linearTexture = this.m_LinearTexture.intValue > 0;
      if (!this.m_RGBM.hasMultipleDifferentValues)
        settings.rgbm = (TextureImporterRGBMMode) this.m_RGBM.intValue;
      if (!this.m_EnableMipMap.hasMultipleDifferentValues)
        settings.mipmapEnabled = this.m_EnableMipMap.intValue > 0;
      if (!this.m_GenerateMipsInLinearSpace.hasMultipleDifferentValues)
        settings.generateMipsInLinearSpace = this.m_GenerateMipsInLinearSpace.intValue > 0;
      if (!this.m_MipMapMode.hasMultipleDifferentValues)
        settings.mipmapFilter = (TextureImporterMipFilter) this.m_MipMapMode.intValue;
      if (!this.m_FadeOut.hasMultipleDifferentValues)
        settings.fadeOut = this.m_FadeOut.intValue > 0;
      if (!this.m_MipMapFadeDistanceStart.hasMultipleDifferentValues)
        settings.mipmapFadeDistanceStart = this.m_MipMapFadeDistanceStart.intValue;
      if (!this.m_MipMapFadeDistanceEnd.hasMultipleDifferentValues)
        settings.mipmapFadeDistanceEnd = this.m_MipMapFadeDistanceEnd.intValue;
      if (!this.m_Lightmap.hasMultipleDifferentValues)
        settings.lightmap = this.m_Lightmap.intValue > 0;
      if (!this.m_SpriteMode.hasMultipleDifferentValues)
        settings.spriteMode = this.m_SpriteMode.intValue;
      if (!this.m_SpritePixelsToUnits.hasMultipleDifferentValues)
        settings.spritePixelsPerUnit = this.m_SpritePixelsToUnits.floatValue;
      if (!this.m_SpriteExtrude.hasMultipleDifferentValues)
        settings.spriteExtrude = (uint) this.m_SpriteExtrude.intValue;
      if (!this.m_SpriteMeshType.hasMultipleDifferentValues)
        settings.spriteMeshType = (SpriteMeshType) this.m_SpriteMeshType.intValue;
      if (!this.m_Alignment.hasMultipleDifferentValues)
        settings.spriteAlignment = this.m_Alignment.intValue;
      if (!this.m_SpritePivot.hasMultipleDifferentValues)
        settings.spritePivot = this.m_SpritePivot.vector2Value;
      if (!this.m_WrapMode.hasMultipleDifferentValues)
        settings.wrapMode = (TextureWrapMode) this.m_WrapMode.intValue;
      if (!this.m_FilterMode.hasMultipleDifferentValues)
        settings.filterMode = (UnityEngine.FilterMode) this.m_FilterMode.intValue;
      if (!this.m_Aniso.hasMultipleDifferentValues)
        settings.aniso = this.m_Aniso.intValue;
      if (!this.m_AlphaIsTransparency.hasMultipleDifferentValues)
        settings.alphaIsTransparency = this.m_AlphaIsTransparency.intValue > 0;
      return settings;
    }

    public override void OnInspectorGUI()
    {
      if (TextureImporterInspector.s_Styles == null)
        TextureImporterInspector.s_Styles = new TextureImporterInspector.Styles();
      bool enabled = GUI.enabled;
      EditorGUI.BeginChangeCheck();
      EditorGUI.showMixedValue = this.textureTypeHasMultipleDifferentValues;
      int num = EditorGUILayout.IntPopup(TextureImporterInspector.s_Styles.textureType, (int) this.textureType, TextureImporterInspector.s_Styles.textureTypeOptions, this.m_TextureTypeValues, new GUILayoutOption[0]);
      EditorGUI.showMixedValue = false;
      if (EditorGUI.EndChangeCheck())
      {
        this.m_TextureType.intValue = num;
        TextureImporterSettings propertySettings = this.GetSerializedPropertySettings();
        propertySettings.ApplyTextureType(this.textureType, true);
        this.SetSerializedPropertySettings(propertySettings);
        this.SyncPlatformSettings();
        this.ApplySettingsToTexture();
      }
      if (!this.textureTypeHasMultipleDifferentValues)
      {
        switch (this.textureType)
        {
          case TextureImporterType.Image:
            this.ImageGUI();
            break;
          case TextureImporterType.Bump:
            this.BumpGUI();
            break;
          case TextureImporterType.Cubemap:
            this.CubemapGUI();
            break;
          case TextureImporterType.Cookie:
            this.CookieGUI();
            break;
          case TextureImporterType.Advanced:
            this.AdvancedGUI();
            break;
          case TextureImporterType.Sprite:
            this.SpriteGUI();
            break;
        }
      }
      EditorGUILayout.Space();
      this.PreviewableGUI();
      this.SizeAndFormatGUI();
      GUILayout.BeginHorizontal();
      GUILayout.FlexibleSpace();
      this.ApplyRevertGUI();
      GUILayout.EndHorizontal();
      this.UpdateImportWarning();
      if (this.m_ImportWarning != null)
        EditorGUILayout.HelpBox(this.m_ImportWarning, MessageType.Warning);
      GUI.enabled = enabled;
    }

    private void PreviewableGUI()
    {
      EditorGUI.BeginChangeCheck();
      if (this.textureType != TextureImporterType.GUI && this.textureType != TextureImporterType.Sprite && (this.textureType != TextureImporterType.Cubemap && this.textureType != TextureImporterType.Cookie) && this.textureType != TextureImporterType.Lightmap)
      {
        EditorGUI.BeginChangeCheck();
        EditorGUI.showMixedValue = this.m_WrapMode.hasMultipleDifferentValues;
        TextureWrapMode textureWrapMode1 = (TextureWrapMode) this.m_WrapMode.intValue;
        if (textureWrapMode1 == ~TextureWrapMode.Repeat)
          textureWrapMode1 = TextureWrapMode.Repeat;
        TextureWrapMode textureWrapMode2 = (TextureWrapMode) EditorGUILayout.EnumPopup(EditorGUIUtility.TempContent("Wrap Mode"), (Enum) textureWrapMode1, new GUILayoutOption[0]);
        EditorGUI.showMixedValue = false;
        if (EditorGUI.EndChangeCheck())
          this.m_WrapMode.intValue = (int) textureWrapMode2;
        if (this.m_NPOTScale.intValue == 0 && textureWrapMode2 == TextureWrapMode.Repeat && !ShaderUtil.hardwareSupportsFullNPOT)
        {
          bool flag = false;
          foreach (UnityEngine.Object target in this.targets)
          {
            int width = -1;
            int height = -1;
            ((TextureImporter) target).GetWidthAndHeight(ref width, ref height);
            if (!Mathf.IsPowerOfTwo(width) || !Mathf.IsPowerOfTwo(height))
            {
              flag = true;
              break;
            }
          }
          if (flag)
            EditorGUILayout.HelpBox(EditorGUIUtility.TextContent("Graphics device doesn't support Repeat wrap mode on NPOT textures. Falling back to Clamp.").text, MessageType.Warning, true);
        }
      }
      EditorGUI.BeginChangeCheck();
      EditorGUI.showMixedValue = this.m_FilterMode.hasMultipleDifferentValues;
      UnityEngine.FilterMode filterMode1 = (UnityEngine.FilterMode) this.m_FilterMode.intValue;
      if (filterMode1 == ~UnityEngine.FilterMode.Point)
        filterMode1 = this.m_FadeOut.intValue > 0 || this.m_ConvertToNormalMap.intValue > 0 || this.m_NormalMap.intValue > 0 ? UnityEngine.FilterMode.Trilinear : UnityEngine.FilterMode.Bilinear;
      UnityEngine.FilterMode filterMode2 = (UnityEngine.FilterMode) EditorGUILayout.IntPopup(TextureImporterInspector.s_Styles.filterMode, (int) filterMode1, TextureImporterInspector.s_Styles.filterModeOptions, this.m_FilterModeOptions, new GUILayoutOption[0]);
      EditorGUI.showMixedValue = false;
      if (EditorGUI.EndChangeCheck())
        this.m_FilterMode.intValue = (int) filterMode2;
      if (filterMode2 != UnityEngine.FilterMode.Point && (this.m_EnableMipMap.intValue > 0 || this.textureType == TextureImporterType.Advanced) && (this.textureType != TextureImporterType.Sprite && this.textureType != TextureImporterType.Cubemap))
      {
        EditorGUI.BeginChangeCheck();
        EditorGUI.showMixedValue = this.m_Aniso.hasMultipleDifferentValues;
        int num = this.m_Aniso.intValue;
        if (num == -1)
          num = 1;
        int anisoLevel = EditorGUILayout.IntSlider("Aniso Level", num, 0, 16, new GUILayoutOption[0]);
        EditorGUI.showMixedValue = false;
        if (EditorGUI.EndChangeCheck())
          this.m_Aniso.intValue = anisoLevel;
        TextureInspector.DoAnisoGlobalSettingNote(anisoLevel);
      }
      if (!EditorGUI.EndChangeCheck())
        return;
      this.ApplySettingsToTexture();
    }

    private void ApplySettingsToTexture()
    {
      foreach (AssetImporter target in this.targets)
      {
        Texture tex = AssetDatabase.LoadMainAssetAtPath(target.assetPath) as Texture;
        if (this.m_Aniso.intValue != -1)
          TextureUtil.SetAnisoLevelNoDirty(tex, this.m_Aniso.intValue);
        if (this.m_FilterMode.intValue != -1)
          TextureUtil.SetFilterModeNoDirty(tex, (UnityEngine.FilterMode) this.m_FilterMode.intValue);
        if (this.m_WrapMode.intValue != -1)
          TextureUtil.SetWrapModeNoDirty(tex, (TextureWrapMode) this.m_WrapMode.intValue);
      }
      SceneView.RepaintAll();
    }

    private static bool CountImportersWithAlpha(UnityEngine.Object[] importers, out int count)
    {
      try
      {
        count = 0;
        foreach (UnityEngine.Object importer in importers)
        {
          if ((importer as TextureImporter).DoesSourceTextureHaveAlpha())
            count = count + 1;
        }
        return true;
      }
      catch
      {
        count = importers.Length;
        return false;
      }
    }

    private void DoAlphaIsTransparencyGUI()
    {
      int count;
      bool flag = TextureImporterInspector.CountImportersWithAlpha(this.targets, out count);
      if (!this.m_GrayscaleToAlpha.boolValue && count != this.targets.Length)
        return;
      EditorGUI.BeginDisabledGroup(!flag);
      this.ToggleFromInt(this.m_AlphaIsTransparency, TextureImporterInspector.s_Styles.alphaIsTransparency);
      EditorGUI.EndDisabledGroup();
    }

    private void ImageGUI()
    {
      if ((UnityEngine.Object) (this.target as TextureImporter) == (UnityEngine.Object) null)
        return;
      this.ToggleFromInt(this.m_GrayscaleToAlpha, TextureImporterInspector.s_Styles.generateAlphaFromGrayscale);
      this.DoAlphaIsTransparencyGUI();
    }

    private void BumpGUI()
    {
      this.ToggleFromInt(this.m_ConvertToNormalMap, TextureImporterInspector.s_Styles.generateFromBump);
      this.m_ShowBumpGenerationSettings.target = this.m_ConvertToNormalMap.intValue > 0;
      if (EditorGUILayout.BeginFadeGroup(this.m_ShowBumpGenerationSettings.faded))
      {
        EditorGUILayout.Slider(this.m_HeightScale, 0.0f, 0.3f, TextureImporterInspector.s_Styles.bumpiness, new GUILayoutOption[0]);
        EditorGUILayout.Popup(this.m_NormalMapFilter, TextureImporterInspector.s_Styles.bumpFilteringOptions, TextureImporterInspector.s_Styles.bumpFiltering, new GUILayoutOption[0]);
      }
      EditorGUILayout.EndFadeGroup();
    }

    private void SpriteGUI()
    {
      this.SpriteGUI(true);
    }

    private void SpriteGUI(bool showMipMapControls)
    {
      EditorGUI.BeginChangeCheck();
      if (this.textureType == TextureImporterType.Advanced)
        EditorGUILayout.IntPopup(this.m_SpriteMode, TextureImporterInspector.s_Styles.spriteModeOptionsAdvanced, new int[4]{ 0, 1, 2, 3 }, TextureImporterInspector.s_Styles.spriteMode, new GUILayoutOption[0]);
      else
        EditorGUILayout.IntPopup(this.m_SpriteMode, TextureImporterInspector.s_Styles.spriteModeOptions, new int[3]{ 1, 2, 3 }, TextureImporterInspector.s_Styles.spriteMode, new GUILayoutOption[0]);
      if (EditorGUI.EndChangeCheck())
        GUIUtility.keyboardControl = 0;
      ++EditorGUI.indentLevel;
      this.m_ShowGenericSpriteSettings.target = this.m_SpriteMode.intValue != 0;
      if (EditorGUILayout.BeginFadeGroup(this.m_ShowGenericSpriteSettings.faded))
      {
        EditorGUILayout.PropertyField(this.m_SpritePackingTag, TextureImporterInspector.s_Styles.spritePackingTag, new GUILayoutOption[0]);
        EditorGUILayout.PropertyField(this.m_SpritePixelsToUnits, TextureImporterInspector.s_Styles.spritePixelsPerUnit, new GUILayoutOption[0]);
        if (this.textureType == TextureImporterType.Advanced)
        {
          EditorGUILayout.IntPopup(this.m_SpriteMeshType, TextureImporterInspector.s_Styles.spriteMeshTypeOptions, new int[2]{ 0, 1 }, TextureImporterInspector.s_Styles.spriteMeshType, new GUILayoutOption[0]);
          EditorGUILayout.IntSlider(this.m_SpriteExtrude, 0, 32, TextureImporterInspector.s_Styles.spriteExtrude, new GUILayoutOption[0]);
        }
        if (this.m_SpriteMode.intValue == 1)
        {
          EditorGUILayout.Popup(this.m_Alignment, TextureImporterInspector.s_Styles.spriteAlignmentOptions, TextureImporterInspector.s_Styles.spriteAlignment, new GUILayoutOption[0]);
          if (this.m_Alignment.intValue == 9)
          {
            GUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(this.m_SpritePivot, this.m_EmptyContent, new GUILayoutOption[0]);
            GUILayout.EndHorizontal();
          }
        }
        EditorGUI.BeginDisabledGroup(this.targets.Length != 1);
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Sprite Editor"))
        {
          if (this.HasModified())
          {
            if (EditorUtility.DisplayDialog("Unapplied import settings", "Unapplied import settings for '" + ((AssetImporter) this.target).assetPath + "'.\n" + "Apply and continue to sprite editor or cancel.", "Apply", "Cancel"))
            {
              this.ApplyAndImport();
              SpriteEditorWindow.GetWindow();
              GUIUtility.ExitGUI();
            }
          }
          else
            SpriteEditorWindow.GetWindow();
        }
        GUILayout.EndHorizontal();
        EditorGUI.EndDisabledGroup();
      }
      EditorGUILayout.EndFadeGroup();
      --EditorGUI.indentLevel;
      if (!showMipMapControls)
        return;
      this.ToggleFromInt(this.m_EnableMipMap, TextureImporterInspector.s_Styles.generateMipMaps);
    }

    private void CubemapGUI()
    {
      this.CubemapMappingGUI(false);
    }

    private void CubemapMappingGUI(bool advancedMode)
    {
      EditorGUI.showMixedValue = this.m_GenerateCubemap.hasMultipleDifferentValues || this.m_SeamlessCubemap.hasMultipleDifferentValues;
      EditorGUI.BeginChangeCheck();
      int count = !advancedMode ? 1 : 0;
      List<GUIContent> guiContentList = new List<GUIContent>((IEnumerable<GUIContent>) TextureImporterInspector.s_Styles.cubemapOptions);
      guiContentList.RemoveRange(0, count);
      List<int> intList = new List<int>((IEnumerable<int>) TextureImporterInspector.s_Styles.cubemapValues);
      intList.RemoveRange(0, count);
      int num = EditorGUILayout.IntPopup(TextureImporterInspector.s_Styles.cubemap, this.m_GenerateCubemap.intValue, guiContentList.ToArray(), intList.ToArray(), new GUILayoutOption[0]);
      if (EditorGUI.EndChangeCheck())
        this.m_GenerateCubemap.intValue = num;
      EditorGUI.BeginDisabledGroup(num == 0);
      if (advancedMode)
        ++EditorGUI.indentLevel;
      if (advancedMode)
      {
        EditorGUILayout.IntPopup(this.m_CubemapConvolution, TextureImporterInspector.s_Styles.cubemapConvolutionOptions, ((IEnumerable<int>) TextureImporterInspector.s_Styles.cubemapConvolutionValues).ToArray<int>(), TextureImporterInspector.s_Styles.cubemapConvolution, new GUILayoutOption[0]);
      }
      else
      {
        this.ToggleFromInt(this.m_CubemapConvolution, TextureImporterInspector.s_Styles.cubemapConvolutionSimple);
        if (this.m_CubemapConvolution.intValue != 0)
          this.m_CubemapConvolution.intValue = 1;
      }
      if (advancedMode)
      {
        this.m_ShowConvolutionCubeMapSettings.target = this.m_CubemapConvolution.intValue == 1;
        if (EditorGUILayout.BeginFadeGroup(this.m_ShowConvolutionCubeMapSettings.faded))
        {
          ++EditorGUI.indentLevel;
          this.m_CubemapConvolutionSteps.intValue = EditorGUILayout.IntField(TextureImporterInspector.s_Styles.cubemapConvolutionSteps, this.m_CubemapConvolutionSteps.intValue, new GUILayoutOption[0]);
          this.m_CubemapConvolutionExponent.floatValue = EditorGUILayout.FloatField(TextureImporterInspector.s_Styles.cubemapConvolutionExp, this.m_CubemapConvolutionExponent.floatValue, new GUILayoutOption[0]);
          --EditorGUI.indentLevel;
        }
        EditorGUILayout.EndFadeGroup();
      }
      this.ToggleFromInt(this.m_SeamlessCubemap, TextureImporterInspector.s_Styles.seamlessCubemap);
      if (advancedMode)
        --EditorGUI.indentLevel;
      EditorGUI.EndDisabledGroup();
      EditorGUI.showMixedValue = false;
    }

    private void CookieGUI()
    {
      EditorGUI.BeginChangeCheck();
      TextureImporterInspector.CookieMode cookieMode = this.m_BorderMipMap.intValue <= 0 ? (this.m_GenerateCubemap.intValue == 0 ? TextureImporterInspector.CookieMode.Directional : TextureImporterInspector.CookieMode.Point) : TextureImporterInspector.CookieMode.Spot;
      TextureImporterInspector.CookieMode cm = (TextureImporterInspector.CookieMode) EditorGUILayout.Popup(TextureImporterInspector.s_Styles.cookieType, (int) cookieMode, TextureImporterInspector.s_Styles.cookieOptions, new GUILayoutOption[0]);
      if (EditorGUI.EndChangeCheck())
        this.SetCookieMode(cm);
      this.m_ShowCookieCubeMapSettings.target = cm == TextureImporterInspector.CookieMode.Point;
      if (EditorGUILayout.BeginFadeGroup(this.m_ShowCookieCubeMapSettings.faded))
        this.CubemapMappingGUI(false);
      EditorGUILayout.EndFadeGroup();
      this.ToggleFromInt(this.m_GrayscaleToAlpha, TextureImporterInspector.s_Styles.generateAlphaFromGrayscale);
    }

    private void SetCookieMode(TextureImporterInspector.CookieMode cm)
    {
      switch (cm)
      {
        case TextureImporterInspector.CookieMode.Spot:
          this.m_BorderMipMap.intValue = 1;
          this.m_WrapMode.intValue = 1;
          this.m_GenerateCubemap.intValue = 0;
          break;
        case TextureImporterInspector.CookieMode.Directional:
          this.m_BorderMipMap.intValue = 0;
          this.m_WrapMode.intValue = 0;
          this.m_GenerateCubemap.intValue = 0;
          break;
        case TextureImporterInspector.CookieMode.Point:
          this.m_BorderMipMap.intValue = 0;
          this.m_WrapMode.intValue = 1;
          this.m_GenerateCubemap.intValue = 1;
          break;
      }
    }

    private void BeginToggleGroup(SerializedProperty property, GUIContent label)
    {
      EditorGUI.showMixedValue = property.hasMultipleDifferentValues;
      EditorGUI.BeginChangeCheck();
      int num = !EditorGUILayout.BeginToggleGroup(label, property.intValue > 0) ? 0 : 1;
      if (EditorGUI.EndChangeCheck())
        property.intValue = num;
      EditorGUI.showMixedValue = false;
    }

    private void AdvancedGUI()
    {
      TextureImporter target = this.target as TextureImporter;
      if ((UnityEngine.Object) target == (UnityEngine.Object) null)
        return;
      int height = 0;
      int width = 0;
      target.GetWidthAndHeight(ref width, ref height);
      bool disabled = TextureImporterInspector.IsPowerOfTwo(height) && TextureImporterInspector.IsPowerOfTwo(width);
      EditorGUI.BeginDisabledGroup(disabled);
      this.EnumPopup(this.m_NPOTScale, typeof (TextureImporterNPOTScale), TextureImporterInspector.s_Styles.npot);
      EditorGUI.EndDisabledGroup();
      EditorGUI.BeginDisabledGroup(!disabled && this.m_NPOTScale.intValue == 0);
      this.CubemapMappingGUI(true);
      EditorGUI.EndDisabledGroup();
      this.ToggleFromInt(this.m_IsReadable, TextureImporterInspector.s_Styles.readWrite);
      TextureImporterInspector.AdvancedTextureType advancedTextureType1 = TextureImporterInspector.AdvancedTextureType.Default;
      if (this.m_NormalMap.intValue > 0)
        advancedTextureType1 = TextureImporterInspector.AdvancedTextureType.NormalMap;
      else if (this.m_Lightmap.intValue > 0)
        advancedTextureType1 = TextureImporterInspector.AdvancedTextureType.LightMap;
      EditorGUI.BeginChangeCheck();
      TextureImporterInspector.AdvancedTextureType advancedTextureType2 = (TextureImporterInspector.AdvancedTextureType) EditorGUILayout.Popup("Import Type", (int) advancedTextureType1, new string[3]{ "Default", "Normal Map", "Lightmap" }, new GUILayoutOption[0]);
      if (EditorGUI.EndChangeCheck())
      {
        switch (advancedTextureType2)
        {
          case TextureImporterInspector.AdvancedTextureType.Default:
            this.m_NormalMap.intValue = 0;
            this.m_Lightmap.intValue = 0;
            this.m_ConvertToNormalMap.intValue = 0;
            break;
          case TextureImporterInspector.AdvancedTextureType.NormalMap:
            this.m_NormalMap.intValue = 1;
            this.m_Lightmap.intValue = 0;
            this.m_LinearTexture.intValue = 1;
            this.m_RGBM.intValue = 0;
            break;
          case TextureImporterInspector.AdvancedTextureType.LightMap:
            this.m_NormalMap.intValue = 0;
            this.m_Lightmap.intValue = 1;
            this.m_ConvertToNormalMap.intValue = 0;
            this.m_LinearTexture.intValue = 1;
            this.m_RGBM.intValue = 0;
            break;
        }
      }
      ++EditorGUI.indentLevel;
      if (advancedTextureType2 == TextureImporterInspector.AdvancedTextureType.NormalMap)
      {
        EditorGUI.BeginChangeCheck();
        this.BumpGUI();
        if (EditorGUI.EndChangeCheck())
          this.SyncPlatformSettings();
      }
      else if (advancedTextureType2 == TextureImporterInspector.AdvancedTextureType.Default)
      {
        this.ToggleFromInt(this.m_GrayscaleToAlpha, TextureImporterInspector.s_Styles.generateAlphaFromGrayscale);
        this.DoAlphaIsTransparencyGUI();
        this.ToggleFromInt(this.m_LinearTexture, TextureImporterInspector.s_Styles.linearTexture);
        EditorGUILayout.Popup(this.m_RGBM, TextureImporterInspector.s_Styles.rgbmEncodingOptions, TextureImporterInspector.s_Styles.rgbmEncoding, new GUILayoutOption[0]);
        this.SpriteGUI(false);
      }
      --EditorGUI.indentLevel;
      this.ToggleFromInt(this.m_EnableMipMap, TextureImporterInspector.s_Styles.generateMipMaps);
      if (!this.m_EnableMipMap.boolValue || this.m_EnableMipMap.hasMultipleDifferentValues)
        return;
      ++EditorGUI.indentLevel;
      this.ToggleFromInt(this.m_GenerateMipsInLinearSpace, TextureImporterInspector.s_Styles.mipMapsInLinearSpace);
      this.ToggleFromInt(this.m_BorderMipMap, TextureImporterInspector.s_Styles.borderMipMaps);
      EditorGUILayout.Popup(this.m_MipMapMode, TextureImporterInspector.s_Styles.mipMapFilterOptions, TextureImporterInspector.s_Styles.mipMapFilter, new GUILayoutOption[0]);
      this.ToggleFromInt(this.m_FadeOut, TextureImporterInspector.s_Styles.mipmapFadeOutToggle);
      if (this.m_FadeOut.intValue > 0)
      {
        ++EditorGUI.indentLevel;
        EditorGUI.BeginChangeCheck();
        float intValue1 = (float) this.m_MipMapFadeDistanceStart.intValue;
        float intValue2 = (float) this.m_MipMapFadeDistanceEnd.intValue;
        EditorGUILayout.MinMaxSlider(TextureImporterInspector.s_Styles.mipmapFadeOut, ref intValue1, ref intValue2, 0.0f, 10f, new GUILayoutOption[0]);
        if (EditorGUI.EndChangeCheck())
        {
          this.m_MipMapFadeDistanceStart.intValue = Mathf.RoundToInt(intValue1);
          this.m_MipMapFadeDistanceEnd.intValue = Mathf.RoundToInt(intValue2);
        }
        --EditorGUI.indentLevel;
      }
      --EditorGUI.indentLevel;
    }

    private void SyncPlatformSettings()
    {
      using (List<TextureImporterInspector.PlatformSetting>.Enumerator enumerator = this.m_PlatformSettings.GetEnumerator())
      {
        while (enumerator.MoveNext())
          enumerator.Current.Sync();
      }
    }

    private static string[] BuildTextureStrings(int[] texFormatValues)
    {
      string[] strArray = new string[texFormatValues.Length];
      for (int index = 0; index < texFormatValues.Length; ++index)
      {
        int texFormatValue = texFormatValues[index];
        switch (texFormatValue + 5)
        {
          case 0:
            strArray[index] = "Automatic Crunched";
            break;
          case 2:
            strArray[index] = "Automatic Truecolor";
            break;
          case 3:
            strArray[index] = "Automatic 16 bits";
            break;
          case 4:
            strArray[index] = "Automatic Compressed";
            break;
          default:
            strArray[index] = " " + TextureUtil.GetTextureFormatString((TextureFormat) texFormatValue);
            break;
        }
      }
      return strArray;
    }

    private static TextureImporterFormat MakeTextureFormatHaveAlpha(TextureImporterFormat format)
    {
      TextureImporterFormat textureImporterFormat = format;
      switch (textureImporterFormat)
      {
        case TextureImporterFormat.RGB16:
          return TextureImporterFormat.ARGB16;
        case TextureImporterFormat.DXT1:
          return TextureImporterFormat.DXT5;
        default:
          switch (textureImporterFormat - 30)
          {
            case ~TextureImporterFormat.AutomaticCompressed:
              return TextureImporterFormat.PVRTC_RGBA2;
            case TextureImporterFormat.ARGB16:
              return TextureImporterFormat.PVRTC_RGBA4;
            default:
              if (textureImporterFormat == TextureImporterFormat.RGB24)
                return TextureImporterFormat.ARGB32;
              return format;
          }
      }
    }

    protected void SizeAndFormatGUI()
    {
      BuildPlayerWindow.BuildPlatform[] array = ((IEnumerable<BuildPlayerWindow.BuildPlatform>) TextureImporterInspector.GetBuildPlayerValidPlatforms()).ToArray<BuildPlayerWindow.BuildPlatform>();
      GUILayout.Space(10f);
      TextureImporterInspector.PlatformSetting platformSetting = this.m_PlatformSettings[EditorGUILayout.BeginPlatformGrouping(array, TextureImporterInspector.s_Styles.defaultPlatform) + 1];
      if (!platformSetting.isDefault)
      {
        EditorGUI.BeginChangeCheck();
        EditorGUI.showMixedValue = platformSetting.overriddenIsDifferent;
        bool overridden = EditorGUILayout.ToggleLeft("Override for " + platformSetting.name, platformSetting.overridden);
        EditorGUI.showMixedValue = false;
        if (EditorGUI.EndChangeCheck())
        {
          platformSetting.SetOverriddenForAll(overridden);
          this.SyncPlatformSettings();
        }
      }
      EditorGUI.BeginDisabledGroup(!platformSetting.isDefault && !platformSetting.allAreOverridden);
      EditorGUI.BeginChangeCheck();
      EditorGUI.showMixedValue = platformSetting.overriddenIsDifferent || platformSetting.maxTextureSizeIsDifferent;
      int maxTextureSize = EditorGUILayout.IntPopup(TextureImporterInspector.s_Styles.maxSize.text, platformSetting.maxTextureSize, TextureImporterInspector.kMaxTextureSizeStrings, TextureImporterInspector.kMaxTextureSizeValues, new GUILayoutOption[0]);
      EditorGUI.showMixedValue = false;
      if (EditorGUI.EndChangeCheck())
      {
        platformSetting.SetMaxTextureSizeForAll(maxTextureSize);
        this.SyncPlatformSettings();
      }
      int[] optionValues = (int[]) null;
      string[] texts = (string[]) null;
      bool flag1 = false;
      int selectedValue = 0;
      bool flag2 = false;
      int num1 = 0;
      bool flag3 = false;
      for (int index = 0; index < this.targets.Length; ++index)
      {
        TextureImporter target = this.targets[index] as TextureImporter;
        TextureImporterType tType = !this.textureTypeHasMultipleDifferentValues ? this.textureType : target.textureType;
        TextureImporterSettings settings = platformSetting.GetSettings(target);
        int num2 = (int) platformSetting.textureFormats[index];
        int num3 = num2;
        if (!platformSetting.isDefault && num2 < 0)
          num3 = (int) TextureImporter.SimpleToFullTextureFormat2((TextureImporterFormat) num3, tType, settings, target.DoesSourceTextureHaveAlpha(), target.IsSourceTextureHDR(), platformSetting.m_Target);
        if (settings.normalMap && !TextureImporterInspector.IsGLESMobileTargetPlatform(platformSetting.m_Target))
          num3 = (int) TextureImporterInspector.MakeTextureFormatHaveAlpha((TextureImporterFormat) num3);
        int[] numArray;
        string[] strArray;
        int num4;
        switch (tType)
        {
          case TextureImporterType.Cookie:
            numArray = new int[1];
            strArray = new string[1]{ "8 Bit Alpha" };
            num4 = 0;
            break;
          case TextureImporterType.Advanced:
            num4 = num3;
            if (TextureImporterInspector.IsGLESMobileTargetPlatform(platformSetting.m_Target))
            {
              if (TextureImporterInspector.s_TextureFormatStringsiPhone == null)
                TextureImporterInspector.s_TextureFormatStringsiPhone = TextureImporterInspector.BuildTextureStrings(TextureImporterInspector.kTextureFormatsValueiPhone);
              if (TextureImporterInspector.s_TextureFormatStringstvOS == null)
                TextureImporterInspector.s_TextureFormatStringstvOS = TextureImporterInspector.BuildTextureStrings(TextureImporterInspector.kTextureFormatsValuetvOS);
              if (TextureImporterInspector.s_TextureFormatStringsAndroid == null)
                TextureImporterInspector.s_TextureFormatStringsAndroid = TextureImporterInspector.BuildTextureStrings(TextureImporterInspector.kTextureFormatsValueAndroid);
              if (platformSetting.m_Target == BuildTarget.iOS)
              {
                numArray = TextureImporterInspector.kTextureFormatsValueiPhone;
                strArray = TextureImporterInspector.s_TextureFormatStringsiPhone;
                break;
              }
              if (platformSetting.m_Target == BuildTarget.tvOS)
              {
                numArray = TextureImporterInspector.kTextureFormatsValuetvOS;
                strArray = TextureImporterInspector.s_TextureFormatStringstvOS;
                break;
              }
              if (platformSetting.m_Target == BuildTarget.SamsungTV)
              {
                if (TextureImporterInspector.s_TextureFormatStringsSTV == null)
                  TextureImporterInspector.s_TextureFormatStringsSTV = TextureImporterInspector.BuildTextureStrings(TextureImporterInspector.kTextureFormatsValueSTV);
                numArray = TextureImporterInspector.kTextureFormatsValueSTV;
                strArray = TextureImporterInspector.s_TextureFormatStringsSTV;
                break;
              }
              numArray = TextureImporterInspector.kTextureFormatsValueAndroid;
              strArray = TextureImporterInspector.s_TextureFormatStringsAndroid;
              break;
            }
            if (!settings.normalMap)
            {
              if (TextureImporterInspector.s_TextureFormatStringsAll == null)
                TextureImporterInspector.s_TextureFormatStringsAll = TextureImporterInspector.BuildTextureStrings(TextureImporterInspector.TextureFormatsValueAll);
              if (TextureImporterInspector.s_TextureFormatStringsWiiU == null)
                TextureImporterInspector.s_TextureFormatStringsWiiU = TextureImporterInspector.BuildTextureStrings(TextureImporterInspector.kTextureFormatsValueWiiU);
              if (TextureImporterInspector.s_TextureFormatStringsGLESEmu == null)
                TextureImporterInspector.s_TextureFormatStringsGLESEmu = TextureImporterInspector.BuildTextureStrings(TextureImporterInspector.kTextureFormatsValueGLESEmu);
              if (TextureImporterInspector.s_TextureFormatStringsWeb == null)
                TextureImporterInspector.s_TextureFormatStringsWeb = TextureImporterInspector.BuildTextureStrings(TextureImporterInspector.kTextureFormatsValueWeb);
              if (platformSetting.isDefault)
              {
                numArray = TextureImporterInspector.TextureFormatsValueAll;
                strArray = TextureImporterInspector.s_TextureFormatStringsAll;
                break;
              }
              if (platformSetting.m_Target == BuildTarget.WiiU)
              {
                numArray = TextureImporterInspector.kTextureFormatsValueWiiU;
                strArray = TextureImporterInspector.s_TextureFormatStringsWiiU;
                break;
              }
              if (platformSetting.m_Target == BuildTarget.StandaloneGLESEmu)
              {
                numArray = TextureImporterInspector.kTextureFormatsValueGLESEmu;
                strArray = TextureImporterInspector.s_TextureFormatStringsGLESEmu;
                break;
              }
              numArray = TextureImporterInspector.kTextureFormatsValueWeb;
              strArray = TextureImporterInspector.s_TextureFormatStringsWeb;
              break;
            }
            if (TextureImporterInspector.s_NormalFormatStringsAll == null)
              TextureImporterInspector.s_NormalFormatStringsAll = TextureImporterInspector.BuildTextureStrings(TextureImporterInspector.NormalFormatsValueAll);
            if (TextureImporterInspector.s_NormalFormatStringsWeb == null)
              TextureImporterInspector.s_NormalFormatStringsWeb = TextureImporterInspector.BuildTextureStrings(TextureImporterInspector.kNormalFormatsValueWeb);
            if (platformSetting.isDefault)
            {
              numArray = TextureImporterInspector.NormalFormatsValueAll;
              strArray = TextureImporterInspector.s_NormalFormatStringsAll;
              break;
            }
            numArray = TextureImporterInspector.kNormalFormatsValueWeb;
            strArray = TextureImporterInspector.s_NormalFormatStringsWeb;
            break;
          default:
            numArray = this.m_TextureFormatValues;
            strArray = ((IEnumerable<GUIContent>) TextureImporterInspector.s_Styles.textureFormatOptions).Select<GUIContent, string>((Func<GUIContent, string>) (content => content.text)).ToArray<string>();
            if (num2 >= 0)
              num2 = (int) TextureImporter.FullToSimpleTextureFormat((TextureImporterFormat) num2);
            num4 = -1 - num2;
            break;
        }
        if (index == 0)
        {
          optionValues = numArray;
          texts = strArray;
          selectedValue = num4;
          num1 = num3;
        }
        else
        {
          if (num4 != selectedValue)
            flag2 = true;
          if (num3 != num1)
            flag3 = true;
          if (!((IEnumerable<int>) numArray).SequenceEqual<int>((IEnumerable<int>) optionValues) || !((IEnumerable<string>) strArray).SequenceEqual<string>((IEnumerable<string>) texts))
          {
            flag1 = true;
            break;
          }
        }
      }
      EditorGUI.BeginDisabledGroup(flag1 || texts.Length == 1);
      EditorGUI.BeginChangeCheck();
      EditorGUI.showMixedValue = flag1 || flag2;
      int num5 = EditorGUILayout.IntPopup(TextureImporterInspector.s_Styles.textureFormat, selectedValue, EditorGUIUtility.TempContent(texts), optionValues, new GUILayoutOption[0]);
      EditorGUI.showMixedValue = false;
      if (this.textureType != TextureImporterType.Advanced)
        num5 = -1 - num5;
      if (EditorGUI.EndChangeCheck())
      {
        platformSetting.SetTextureFormatForAll((TextureImporterFormat) num5);
        this.SyncPlatformSettings();
      }
      EditorGUI.EndDisabledGroup();
      if (num1 == -5 || !flag3 && ArrayUtility.Contains<TextureImporterFormat>(TextureImporterInspector.kFormatsWithCompressionSettings, (TextureImporterFormat) num1))
      {
        EditorGUI.BeginChangeCheck();
        EditorGUI.showMixedValue = platformSetting.overriddenIsDifferent || platformSetting.compressionQualityIsDifferent;
        int quality = this.EditCompressionQuality(platformSetting.m_Target, platformSetting.compressionQuality);
        EditorGUI.showMixedValue = false;
        if (EditorGUI.EndChangeCheck())
        {
          platformSetting.SetCompressionQualityForAll(quality);
          this.SyncPlatformSettings();
        }
      }
      if (TextureImporter.FullToSimpleTextureFormat((TextureImporterFormat) num5) == TextureImporterFormat.AutomaticCrunched && TextureImporter.FullToSimpleTextureFormat((TextureImporterFormat) num1) != TextureImporterFormat.AutomaticCrunched)
        EditorGUILayout.HelpBox("Crunched is not supported on this platform. Falling back to 'Compressed'.", MessageType.Warning);
      bool flag4 = num5 == -1 || TextureImporter.IsTextureFormatETC1Compression((TextureFormat) num1);
      if (platformSetting.overridden && platformSetting.m_Target == BuildTarget.Android && (flag4 && platformSetting.importers.Length > 0))
      {
        TextureImporter importer1 = platformSetting.importers[0];
        EditorGUI.BeginChangeCheck();
        bool flag5 = GUILayout.Toggle(importer1.GetAllowsAlphaSplitting(), TextureImporterInspector.s_Styles.etc1Compression);
        if (EditorGUI.EndChangeCheck())
        {
          foreach (TextureImporter importer2 in platformSetting.importers)
            importer2.SetAllowsAlphaSplitting(flag5);
          platformSetting.SetChanged();
        }
      }
      if (!platformSetting.overridden && platformSetting.m_Target == BuildTarget.Android && (platformSetting.importers.Length > 0 && platformSetting.importers[0].GetAllowsAlphaSplitting()))
      {
        platformSetting.importers[0].SetAllowsAlphaSplitting(false);
        platformSetting.SetChanged();
      }
      EditorGUI.EndDisabledGroup();
      EditorGUILayout.EndPlatformGrouping();
    }

    private int EditCompressionQuality(BuildTarget target, int compression)
    {
      if (target == BuildTarget.tvOS || target == BuildTarget.iOS || (target == BuildTarget.Android || target == BuildTarget.BlackBerry) || (target == BuildTarget.Tizen || target == BuildTarget.SamsungTV))
      {
        int selectedIndex = 1;
        if (compression == 0)
          selectedIndex = 0;
        else if (compression == 100)
          selectedIndex = 2;
        switch (EditorGUILayout.Popup(TextureImporterInspector.s_Styles.compressionQuality, selectedIndex, TextureImporterInspector.s_Styles.mobileCompressionQualityOptions, new GUILayoutOption[0]))
        {
          case 0:
            return 0;
          case 1:
            return 50;
          case 2:
            return 100;
          default:
            return 50;
        }
      }
      else
      {
        compression = EditorGUILayout.IntSlider(TextureImporterInspector.s_Styles.compressionQualitySlider, compression, 0, 100, new GUILayoutOption[0]);
        return compression;
      }
    }

    private static bool IsPowerOfTwo(int f)
    {
      return (f & f - 1) == 0;
    }

    public static BuildPlayerWindow.BuildPlatform[] GetBuildPlayerValidPlatforms()
    {
      List<BuildPlayerWindow.BuildPlatform> validPlatforms = BuildPlayerWindow.GetValidPlatforms();
      List<BuildPlayerWindow.BuildPlatform> buildPlatformList = new List<BuildPlayerWindow.BuildPlatform>();
      using (List<BuildPlayerWindow.BuildPlatform>.Enumerator enumerator = validPlatforms.GetEnumerator())
      {
        while (enumerator.MoveNext())
        {
          BuildPlayerWindow.BuildPlatform current = enumerator.Current;
          buildPlatformList.Add(current);
        }
      }
      return buildPlatformList.ToArray();
    }

    public virtual void BuildTargetList()
    {
      BuildPlayerWindow.BuildPlatform[] playerValidPlatforms = TextureImporterInspector.GetBuildPlayerValidPlatforms();
      this.m_PlatformSettings = new List<TextureImporterInspector.PlatformSetting>();
      this.m_PlatformSettings.Add(new TextureImporterInspector.PlatformSetting(string.Empty, BuildTarget.StandaloneWindows, this));
      foreach (BuildPlayerWindow.BuildPlatform buildPlatform in playerValidPlatforms)
        this.m_PlatformSettings.Add(new TextureImporterInspector.PlatformSetting(buildPlatform.name, buildPlatform.DefaultTarget, this));
    }

    internal override bool HasModified()
    {
      if (base.HasModified())
        return true;
      using (List<TextureImporterInspector.PlatformSetting>.Enumerator enumerator = this.m_PlatformSettings.GetEnumerator())
      {
        while (enumerator.MoveNext())
        {
          if (enumerator.Current.HasChanged())
            return true;
        }
      }
      return false;
    }

    public static void SelectMainAssets(UnityEngine.Object[] targets)
    {
      ArrayList arrayList = new ArrayList();
      foreach (AssetImporter target in targets)
      {
        Texture texture = AssetDatabase.LoadMainAssetAtPath(target.assetPath) as Texture;
        if ((bool) ((UnityEngine.Object) texture))
          arrayList.Add((object) texture);
      }
      Selection.objects = arrayList.ToArray(typeof (UnityEngine.Object)) as UnityEngine.Object[];
    }

    internal override void ResetValues()
    {
      base.ResetValues();
      this.CacheSerializedProperties();
      this.BuildTargetList();
      this.ApplySettingsToTexture();
      TextureImporterInspector.SelectMainAssets(this.targets);
    }

    internal override void Apply()
    {
      SpriteEditorWindow.TextureImporterApply(this.serializedObject);
      base.Apply();
      this.SyncPlatformSettings();
      using (List<TextureImporterInspector.PlatformSetting>.Enumerator enumerator = this.m_PlatformSettings.GetEnumerator())
      {
        while (enumerator.MoveNext())
          enumerator.Current.Apply();
      }
    }

    private enum AdvancedTextureType
    {
      Default,
      NormalMap,
      LightMap,
    }

    [Serializable]
    protected class PlatformSetting
    {
      [SerializeField]
      public string name;
      [SerializeField]
      private bool m_Overridden;
      [SerializeField]
      private bool m_OverriddenIsDifferent;
      [SerializeField]
      private int m_MaxTextureSize;
      [SerializeField]
      private bool m_MaxTextureSizeIsDifferent;
      [SerializeField]
      private int m_CompressionQuality;
      [SerializeField]
      private bool m_CompressionQualityIsDifferent;
      [SerializeField]
      private TextureImporterFormat[] m_TextureFormatArray;
      [SerializeField]
      private bool m_TextureFormatIsDifferent;
      [SerializeField]
      public BuildTarget m_Target;
      [SerializeField]
      private TextureImporter[] m_Importers;
      [SerializeField]
      private bool m_HasChanged;
      [SerializeField]
      private TextureImporterInspector m_Inspector;

      public bool overridden
      {
        get
        {
          return this.m_Overridden;
        }
      }

      public bool overriddenIsDifferent
      {
        get
        {
          return this.m_OverriddenIsDifferent;
        }
      }

      public bool allAreOverridden
      {
        get
        {
          if (this.isDefault)
            return true;
          if (this.m_Overridden)
            return !this.m_OverriddenIsDifferent;
          return false;
        }
      }

      public int maxTextureSize
      {
        get
        {
          return this.m_MaxTextureSize;
        }
      }

      public bool maxTextureSizeIsDifferent
      {
        get
        {
          return this.m_MaxTextureSizeIsDifferent;
        }
      }

      public int compressionQuality
      {
        get
        {
          return this.m_CompressionQuality;
        }
      }

      public bool compressionQualityIsDifferent
      {
        get
        {
          return this.m_CompressionQualityIsDifferent;
        }
      }

      public TextureImporterFormat[] textureFormats
      {
        get
        {
          return this.m_TextureFormatArray;
        }
      }

      public bool textureFormatIsDifferent
      {
        get
        {
          return this.m_TextureFormatIsDifferent;
        }
      }

      public TextureImporter[] importers
      {
        get
        {
          return this.m_Importers;
        }
      }

      public bool isDefault
      {
        get
        {
          return this.name == string.Empty;
        }
      }

      public PlatformSetting(string name, BuildTarget target, TextureImporterInspector inspector)
      {
        this.name = name;
        this.m_Target = target;
        this.m_Inspector = inspector;
        this.m_Overridden = false;
        this.m_Importers = ((IEnumerable<UnityEngine.Object>) inspector.targets).Select<UnityEngine.Object, TextureImporter>((Func<UnityEngine.Object, TextureImporter>) (x => x as TextureImporter)).ToArray<TextureImporter>();
        this.m_TextureFormatArray = new TextureImporterFormat[this.importers.Length];
        for (int index = 0; index < this.importers.Length; ++index)
        {
          TextureImporter importer = this.importers[index];
          int maxTextureSize;
          TextureImporterFormat textureFormat;
          int compressionQuality;
          bool flag;
          if (!this.isDefault)
          {
            flag = importer.GetPlatformTextureSettings(name, out maxTextureSize, out textureFormat, out compressionQuality);
          }
          else
          {
            flag = true;
            maxTextureSize = importer.maxTextureSize;
            textureFormat = importer.textureFormat;
            compressionQuality = importer.compressionQuality;
          }
          this.m_TextureFormatArray[index] = textureFormat;
          if (index == 0)
          {
            this.m_Overridden = flag;
            this.m_MaxTextureSize = maxTextureSize;
            this.m_CompressionQuality = compressionQuality;
          }
          else
          {
            if (flag != this.m_Overridden)
              this.m_OverriddenIsDifferent = true;
            if (maxTextureSize != this.m_MaxTextureSize)
              this.m_MaxTextureSizeIsDifferent = true;
            if (compressionQuality != this.m_CompressionQuality)
              this.m_CompressionQualityIsDifferent = true;
            if (textureFormat != this.m_TextureFormatArray[0])
              this.m_TextureFormatIsDifferent = true;
          }
        }
        this.Sync();
      }

      public void SetOverriddenForAll(bool overridden)
      {
        this.m_Overridden = overridden;
        this.m_OverriddenIsDifferent = false;
        this.m_HasChanged = true;
      }

      public void SetMaxTextureSizeForAll(int maxTextureSize)
      {
        this.m_MaxTextureSize = maxTextureSize;
        this.m_MaxTextureSizeIsDifferent = false;
        this.m_HasChanged = true;
      }

      public void SetCompressionQualityForAll(int quality)
      {
        this.m_CompressionQuality = quality;
        this.m_CompressionQualityIsDifferent = false;
        this.m_HasChanged = true;
      }

      public void SetTextureFormatForAll(TextureImporterFormat format)
      {
        for (int index = 0; index < this.m_TextureFormatArray.Length; ++index)
          this.m_TextureFormatArray[index] = format;
        this.m_TextureFormatIsDifferent = false;
        this.m_HasChanged = true;
      }

      public bool SupportsFormat(TextureImporterFormat format, TextureImporter importer)
      {
        TextureImporterSettings settings = this.GetSettings(importer);
        BuildTarget target = this.m_Target;
        int[] numArray;
        switch (target)
        {
          case BuildTarget.BlackBerry:
            numArray = TextureImporterInspector.kTextureFormatsValueBB10;
            break;
          case BuildTarget.Tizen:
            numArray = TextureImporterInspector.kTextureFormatsValueTizen;
            break;
          case BuildTarget.SamsungTV:
            numArray = TextureImporterInspector.kTextureFormatsValueSTV;
            break;
          case BuildTarget.WiiU:
            numArray = TextureImporterInspector.kTextureFormatsValueWiiU;
            break;
          case BuildTarget.tvOS:
            numArray = TextureImporterInspector.kTextureFormatsValuetvOS;
            break;
          default:
            switch (target - 9)
            {
              case ~BuildTarget.iPhone:
                numArray = TextureImporterInspector.kTextureFormatsValueiPhone;
                break;
              case BuildTarget.StandaloneOSXIntel:
                numArray = TextureImporterInspector.kTextureFormatsValueAndroid;
                break;
              case BuildTarget.StandaloneWindows:
                numArray = !settings.normalMap ? TextureImporterInspector.kTextureFormatsValueGLESEmu : TextureImporterInspector.kNormalFormatsValueWeb;
                break;
              default:
                numArray = !settings.normalMap ? TextureImporterInspector.kTextureFormatsValueWeb : TextureImporterInspector.kNormalFormatsValueWeb;
                break;
            }
        }
        return numArray.Contains((object) format);
      }

      public TextureImporterSettings GetSettings(TextureImporter importer)
      {
        TextureImporterSettings importerSettings = new TextureImporterSettings();
        importer.ReadTextureSettings(importerSettings);
        this.m_Inspector.GetSerializedPropertySettings(importerSettings);
        return importerSettings;
      }

      public virtual void SetChanged()
      {
        this.m_HasChanged = true;
      }

      public virtual bool HasChanged()
      {
        return this.m_HasChanged;
      }

      public void Sync()
      {
        if (!this.isDefault && (!this.m_Overridden || this.m_OverriddenIsDifferent))
        {
          TextureImporterInspector.PlatformSetting platformSetting = this.m_Inspector.m_PlatformSettings[0];
          this.m_MaxTextureSize = platformSetting.m_MaxTextureSize;
          this.m_MaxTextureSizeIsDifferent = platformSetting.m_MaxTextureSizeIsDifferent;
          this.m_TextureFormatArray = (TextureImporterFormat[]) platformSetting.m_TextureFormatArray.Clone();
          this.m_TextureFormatIsDifferent = platformSetting.m_TextureFormatIsDifferent;
          this.m_CompressionQuality = platformSetting.m_CompressionQuality;
          this.m_CompressionQualityIsDifferent = platformSetting.m_CompressionQualityIsDifferent;
        }
        TextureImporterType textureType = this.m_Inspector.textureType;
        for (int index = 0; index < this.importers.Length; ++index)
        {
          TextureImporter importer = this.importers[index];
          TextureImporterSettings settings = this.GetSettings(importer);
          if (textureType == TextureImporterType.Advanced)
          {
            if (!this.isDefault)
            {
              if (!this.SupportsFormat(this.m_TextureFormatArray[index], importer))
                this.m_TextureFormatArray[index] = TextureImporter.FullToSimpleTextureFormat(this.m_TextureFormatArray[index]);
              if (this.m_TextureFormatArray[index] < ~TextureImporterFormat.AutomaticCompressed)
                this.m_TextureFormatArray[index] = TextureImporter.SimpleToFullTextureFormat2(this.m_TextureFormatArray[index], textureType, settings, importer.DoesSourceTextureHaveAlpha(), importer.IsSourceTextureHDR(), this.m_Target);
            }
            else
              continue;
          }
          else if (this.m_TextureFormatArray[index] >= ~TextureImporterFormat.AutomaticCompressed)
            this.m_TextureFormatArray[index] = TextureImporter.FullToSimpleTextureFormat(this.m_TextureFormatArray[index]);
          if (settings.normalMap && !TextureImporterInspector.IsGLESMobileTargetPlatform(this.m_Target))
            this.m_TextureFormatArray[index] = TextureImporterInspector.MakeTextureFormatHaveAlpha(this.m_TextureFormatArray[index]);
        }
        this.m_TextureFormatIsDifferent = false;
        foreach (TextureImporterFormat textureFormat in this.m_TextureFormatArray)
        {
          if (textureFormat != this.m_TextureFormatArray[0])
            this.m_TextureFormatIsDifferent = true;
        }
      }

      private bool GetOverridden(TextureImporter importer)
      {
        if (!this.m_OverriddenIsDifferent)
          return this.m_Overridden;
        int maxTextureSize;
        TextureImporterFormat textureFormat;
        return importer.GetPlatformTextureSettings(this.name, out maxTextureSize, out textureFormat);
      }

      public void Apply()
      {
        for (int index = 0; index < this.importers.Length; ++index)
        {
          TextureImporter importer = this.importers[index];
          int compressionQuality = -1;
          bool flag = false;
          int maxTextureSize;
          if (this.isDefault)
          {
            maxTextureSize = importer.maxTextureSize;
          }
          else
          {
            TextureImporterFormat textureFormat;
            flag = importer.GetPlatformTextureSettings(this.name, out maxTextureSize, out textureFormat, out compressionQuality);
          }
          if (!flag)
            maxTextureSize = importer.maxTextureSize;
          if (!this.m_MaxTextureSizeIsDifferent)
            maxTextureSize = this.m_MaxTextureSize;
          if (!this.m_CompressionQualityIsDifferent)
            compressionQuality = this.m_CompressionQuality;
          if (!this.isDefault)
          {
            if (!this.m_OverriddenIsDifferent)
              flag = this.m_Overridden;
            bool allowsAlphaSplitting = importer.GetAllowsAlphaSplitting();
            if (flag)
              importer.SetPlatformTextureSettings(this.name, maxTextureSize, this.m_TextureFormatArray[index], compressionQuality, allowsAlphaSplitting);
            else
              importer.ClearPlatformTextureSettings(this.name);
          }
          else
          {
            importer.maxTextureSize = maxTextureSize;
            importer.textureFormat = this.m_TextureFormatArray[index];
            importer.compressionQuality = compressionQuality;
          }
        }
      }
    }

    private enum CookieMode
    {
      Spot,
      Directional,
      Point,
    }

    private class Styles
    {
      public readonly GUIContent textureType = EditorGUIUtility.TextContent("Texture Type|What will this texture be used for?");
      public readonly GUIContent[] textureTypeOptions = new GUIContent[9]{ EditorGUIUtility.TextContent("Texture|Texture is a normal image such as a diffuse texture or other."), EditorGUIUtility.TextContent("Normal map|Texture is a bump or normal map."), EditorGUIUtility.TextContent("Editor GUI and Legacy GUI|Texture is used for a GUI element."), EditorGUIUtility.TextContent("Sprite (2D and UI)|Texture is used for a sprite."), EditorGUIUtility.TextContent("Cursor|Texture is used for a cursor."), EditorGUIUtility.TextContent("Cubemap|Texture is a cubemap."), EditorGUIUtility.TextContent("Cookie|Texture is a cookie you put on a light."), EditorGUIUtility.TextContent("Lightmap|Texture is a lightmap."), EditorGUIUtility.TextContent("Advanced|All settings displayed.") };
      public readonly GUIContent filterMode = EditorGUIUtility.TextContent("Filter Mode");
      public readonly GUIContent[] filterModeOptions = new GUIContent[3]{ EditorGUIUtility.TextContent("Point (no filter)"), EditorGUIUtility.TextContent("Bilinear"), EditorGUIUtility.TextContent("Trilinear") };
      public readonly GUIContent generateAlphaFromGrayscale = EditorGUIUtility.TextContent("Alpha from Grayscale|Generate texture's alpha channel from grayscale.");
      public readonly GUIContent cookieType = EditorGUIUtility.TextContent("Light Type");
      public readonly GUIContent[] cookieOptions = new GUIContent[3]{ EditorGUIUtility.TextContent("Spotlight"), EditorGUIUtility.TextContent("Directional"), EditorGUIUtility.TextContent("Point") };
      public readonly GUIContent generateFromBump = EditorGUIUtility.TextContent("Create from Grayscale|The grayscale of the image is used as a heightmap for generating the normal map.");
      public readonly GUIContent generateBumpmap = EditorGUIUtility.TextContent("Create bump map");
      public readonly GUIContent bumpiness = EditorGUIUtility.TextContent("Bumpiness");
      public readonly GUIContent bumpFiltering = EditorGUIUtility.TextContent("Filtering");
      public readonly GUIContent[] bumpFilteringOptions = new GUIContent[2]{ EditorGUIUtility.TextContent("Sharp"), EditorGUIUtility.TextContent("Smooth") };
      public readonly GUIContent cubemap = EditorGUIUtility.TextContent("Mapping");
      public readonly GUIContent[] cubemapOptions = new GUIContent[5]{ EditorGUIUtility.TextContent("None"), EditorGUIUtility.TextContent("Auto"), EditorGUIUtility.TextContent("6 Frames Layout (Cubic Environment)|Texture contains 6 images arranged in one of the standard cubemap layouts - cross or sequence (+x,-x, +y, -y, +z, -z). Texture can be in vertical or horizontal orientation."), EditorGUIUtility.TextContent("Latitude-Longitude Layout (Cylindrical)|Texture contains an image of a ball unwrapped such that latitude and longitude are mapped to horizontal and vertical dimensions (as on a globe)."), EditorGUIUtility.TextContent("Mirrored Ball (Spheremap)|Texture contains an image of a mirrored ball.") };
      public readonly int[] cubemapValues = new int[5]{ 0, 6, 5, 2, 1 };
      public readonly GUIContent cubemapConvolution = EditorGUIUtility.TextContent("Convolution Type");
      public readonly GUIContent[] cubemapConvolutionOptions = new GUIContent[3]{ EditorGUIUtility.TextContent("None"), EditorGUIUtility.TextContent("Specular (Glossy Reflection)|Convolve cubemap for specular reflections with varying smoothness (Glossy Reflections)."), EditorGUIUtility.TextContent("Diffuse (Irradiance)|Convolve cubemap for diffuse-only reflection (Irradiance Cubemap).") };
      public readonly int[] cubemapConvolutionValues = new int[3]{ 0, 1, 2 };
      public readonly GUIContent cubemapConvolutionSimple = EditorGUIUtility.TextContent("Glossy Reflection");
      public readonly GUIContent cubemapConvolutionSteps = EditorGUIUtility.TextContent("Steps|Number of smoothness steps represented in mip maps of the cubemap.");
      public readonly GUIContent cubemapConvolutionExp = EditorGUIUtility.TextContent("Exponent|Defines smoothness curve (x^exponent) for convolution.");
      public readonly GUIContent seamlessCubemap = EditorGUIUtility.TextContent("Fixup Edge Seams|Enable if this texture is used for glossy reflections.");
      public readonly GUIContent maxSize = EditorGUIUtility.TextContent("Max Size|Textures larger than this will be scaled down.");
      public readonly GUIContent textureFormat = EditorGUIUtility.TextContent("Format");
      public readonly GUIContent[] textureFormatOptions = new GUIContent[4]{ EditorGUIUtility.TextContent("Compressed"), EditorGUIUtility.TextContent("16 bits"), EditorGUIUtility.TextContent("Truecolor"), EditorGUIUtility.TextContent("Crunched") };
      public readonly GUIContent defaultPlatform = EditorGUIUtility.TextContent("Default");
      public readonly GUIContent mipmapFadeOutToggle = EditorGUIUtility.TextContent("Fadeout Mip Maps");
      public readonly GUIContent mipmapFadeOut = EditorGUIUtility.TextContent("Fade Range");
      public readonly GUIContent readWrite = EditorGUIUtility.TextContent("Read/Write Enabled|Enable to be able to access the raw pixel data from code.");
      public readonly GUIContent rgbmEncoding = EditorGUIUtility.TextContent("Encode as RGBM|Encode texture as RGBM (for HDR textures).");
      public readonly GUIContent[] rgbmEncodingOptions = new GUIContent[4]{ EditorGUIUtility.TextContent("Auto"), EditorGUIUtility.TextContent("On"), EditorGUIUtility.TextContent("Off"), EditorGUIUtility.TextContent("Encoded") };
      public readonly GUIContent generateMipMaps = EditorGUIUtility.TextContent("Generate Mip Maps");
      public readonly GUIContent mipMapsInLinearSpace = EditorGUIUtility.TextContent("In Linear Space|Perform mip map generation in linear space.");
      public readonly GUIContent linearTexture = EditorGUIUtility.TextContent("Bypass sRGB Sampling|Texture will not be converted from gamma space to linear when sampled. Enable for IMGUI textures and non-color textures.");
      public readonly GUIContent borderMipMaps = EditorGUIUtility.TextContent("Border Mip Maps");
      public readonly GUIContent mipMapFilter = EditorGUIUtility.TextContent("Mip Map Filtering");
      public readonly GUIContent[] mipMapFilterOptions = new GUIContent[2]{ EditorGUIUtility.TextContent("Box"), EditorGUIUtility.TextContent("Kaiser") };
      public readonly GUIContent normalmap = EditorGUIUtility.TextContent("Normal Map|Enable if this texture is a normal map baked out of a 3D package.");
      public readonly GUIContent npot = EditorGUIUtility.TextContent("Non Power of 2|How non-power-of-two textures are scaled on import.");
      public readonly GUIContent generateCubemap = EditorGUIUtility.TextContent("Generate Cubemap");
      public readonly GUIContent lightmap = EditorGUIUtility.TextContent("Lightmap|Enable if this is a lightmap (best if stored in EXR format).");
      public readonly GUIContent compressionQuality = EditorGUIUtility.TextContent("Compression Quality");
      public readonly GUIContent compressionQualitySlider = EditorGUIUtility.TextContent("Compression Quality|Use the slider to adjust compression quality from 0 (Fastest) to 100 (Best)");
      public readonly GUIContent[] mobileCompressionQualityOptions = new GUIContent[3]{ EditorGUIUtility.TextContent("Fast"), EditorGUIUtility.TextContent("Normal"), EditorGUIUtility.TextContent("Best") };
      public readonly GUIContent spriteMode = EditorGUIUtility.TextContent("Sprite Mode");
      public readonly GUIContent[] spriteModeOptions = new GUIContent[3]{ EditorGUIUtility.TextContent("Single"), EditorGUIUtility.TextContent("Multiple"), EditorGUIUtility.TextContent("Polygon") };
      public readonly GUIContent[] spriteModeOptionsAdvanced = new GUIContent[4]{ EditorGUIUtility.TextContent("None"), EditorGUIUtility.TextContent("Single"), EditorGUIUtility.TextContent("Multiple"), EditorGUIUtility.TextContent("Polygon") };
      public readonly GUIContent[] spriteMeshTypeOptions = new GUIContent[2]{ EditorGUIUtility.TextContent("Full Rect"), EditorGUIUtility.TextContent("Tight") };
      public readonly GUIContent spritePackingTag = EditorGUIUtility.TextContent("Packing Tag|Tag for the Sprite Packing system.");
      public readonly GUIContent spritePixelsPerUnit = EditorGUIUtility.TextContent("Pixels Per Unit|How many pixels in the sprite correspond to one unit in the world.");
      public readonly GUIContent spriteExtrude = EditorGUIUtility.TextContent("Extrude Edges|How much empty area to leave around the sprite in the generated mesh.");
      public readonly GUIContent spriteMeshType = EditorGUIUtility.TextContent("Mesh Type|Type of sprite mesh to generate.");
      public readonly GUIContent spriteAlignment = EditorGUIUtility.TextContent("Pivot|Sprite pivot point in its localspace. May be used for syncing animation frames of different sizes.");
      public readonly GUIContent[] spriteAlignmentOptions = new GUIContent[10]{ EditorGUIUtility.TextContent("Center"), EditorGUIUtility.TextContent("Top Left"), EditorGUIUtility.TextContent("Top"), EditorGUIUtility.TextContent("Top Right"), EditorGUIUtility.TextContent("Left"), EditorGUIUtility.TextContent("Right"), EditorGUIUtility.TextContent("Bottom Left"), EditorGUIUtility.TextContent("Bottom"), EditorGUIUtility.TextContent("Bottom Right"), EditorGUIUtility.TextContent("Custom") };
      public readonly GUIContent alphaIsTransparency = EditorGUIUtility.TextContent("Alpha Is Transparency");
      public readonly GUIContent etc1Compression = EditorGUIUtility.TextContent("Compress using ETC1 (split alpha channel)|This texture will be placed in an atlas that will be compressed using ETC1 compression, provided that the Texture Compression for Android build settings is set to 'ETC (default)'.");
    }
  }
}
