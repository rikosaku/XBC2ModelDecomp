﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace XBC2ModelDecomp
{
    public class Structs
    {
        //wismt
        public struct MSRD
        {
            public int Version;
            public int HeaderSize;
            public int MainOffset;

            public int Tag;
            public int Revision;

            public int DataItemsCount;
            public int DataItemsOffset;
            public int FileCount;
            public int TOCOffset;

            public byte[] Unknown1;

            public int TextureIdsCount;
            public int TextureIdsOffset;
            public int TextureCountOffset;

            public MSRDDataItem[] DataItems;
            public TOC[] TOC;

            public short[] TextureIds;
            public int TextureCount;
            public int TextureChunkSize;
            public int Unknown2; //texture related
            public int TextureStringBufferOffset;
            public MSRDTextureInfo[] TextureInfo;
            public string[] TextureNames;
        }

        public enum MSRDDataItemTypes : ushort
        {
            Model = 0,
            ShaderBundle,
            CachedTexture,
            Texture
        }

        public struct MSRDDataItem
        {
            public int Offset;
            public int Size;
            public short id1;
            public MSRDDataItemTypes Type;
        }

        public struct TOC
        {
            public int CompSize;
            public int FileSize;
            public int Offset;
        }

        public struct MSRDTexture
        {
            public int Size;
            public int Offset;
            public string Name;
        }

        public struct MSRDTextureInfo
        {
            public int Unknown1;
            public int Size;
            public int Offset;
            public int StringOffset;
        }

        //wimdo
        public struct MXMD
        {
            public int Version;

            public int ModelStructOffset;
            public int MaterialsOffset;

            public int Unknown1;

            public int VertexBufferOffset;
            public int ShadersOffset;
            public int CachedTexturesTableOffset;
            public int Unknown2;
            public int UncachedTexturesTableOffset;

            public byte[] Unknown3; //0x28 long

            public MXMDModelStruct ModelStruct;
        }

        public struct MXMDModelStruct
        {
            public int Unknown1;
            public Vector3 BoundingBoxStart;
            public Vector3 BoundingBoxEnd;
            public int MeshesOffset;
            public int Unknown2;
            public int Unknown3;
            public int NodesOffset;

            public byte[] Unknown4; //0x54 long

            public int MorphControllersOffset;
            public int MorphNamesOffset;

            public MXMDMorphControls MorphControls;

            public MXMDMorphNames MorphNames;

            public MXMDMeshes Meshes;

            public MXMDNodes Nodes;
        }

        public struct MXMDMorphControls
        {
            public int Unknown1;
            public int Count;

            public byte[] Unknown2; //0x10 long

            public MXMDMorphControl[] Controls;
        }

        public struct MXMDMorphControl
        {
            public int NameOffset1;
            public int NameOffset2;

            public byte[] Unknown1; //0x14 long

            public string Name; //not in real struct
        }

        public struct MXMDMorphNames
        {
            public int Unknown1;
            public int Count;

            public byte[] Unknown2; //0x20 long

            public MXMDMorphName[] Names;
        }

        public struct MXMDMorphName
        {
            public int NameOffset;
            public int Unknown1;
            public int Unknown2;
            public int Unknown3;

            public string Name; //not in real struct
        }

        public struct MXMDMeshes
        {
            public int TableOffset;
            public int TableCount;
            public int Unknown1;

            public Vector3 BoundingBoxStart;
            public Vector3 BoundingBoxEnd;
            public float BoundingRadius;

            public MXMDMesh[] Meshes;
        }

        public struct MXMDMesh
        {
            public int ID;

            public int Descriptor;
            public int WeightBind; //not in struct

            public short VTBuffer;
            public short UVFaces;

            public short Unknown1;
            public short MaterialID;
            public byte[] Unknown2; //0xC long
            public short Unknown3;

            public short LOD;
            public int Unknown4;

            public byte[] Unknown5;
        }

        public struct MXMDNodes
        {
            public int BoneCount;
            public int BoneCount2;

            public int NodeIdsOffset;
            public int NodeTmsOffset;

            public MXMDNode[] Nodes;
        }

        public struct MXMDNode
        {
            public int NameOffset;
            public float Unknown1;
            public int Unknown2;

            public int ID;
            public int Unknown3;
            public int Unknown4;
        }
    }
}
